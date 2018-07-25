/**
*  This file is part of the RadX project
*
*  Copyright (c) 2016 radx.plugin@gmail.com
*
*  Checkout AUTHORS file for more information on the developers
*
*  This library is free software; you can redistribute it and/or
*  modify it under the terms of the GNU Lesser General Public
*  License as published by the Free Software Foundation; either
*  version 2.1 of the License, or (at your option) any later version.
*
*  This library is distributed in the hope that it will be useful,
*  but WITHOUT ANY WARRANTY; without even the implied warranty of
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
*  Lesser General Public License for more details.
*
*  You should have received a copy of the GNU Lesser General Public
*  License along with this library; if not, write to the Free Software
*  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307
*  USA
*/
using System;
using System.Generics.Collections;
using System.Base;
using System.SysUtils;
using System.Classes;
using System.UITypes;
using Xcl.Controls;
using Xcl.Forms;
#if __ANDROID__
using Android.Widget;
using Android.Views;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Content;


namespace Xcl.ComCtrls
{

	public partial class TToolbar: TFocusControl
	{		
		public Toolbar toolbar;

		protected override void CreateNativeHandle()
		{
			//Creates the native handle
			toolbar = new Toolbar (TApplication.context);
			//var color = new TColor (TColors.clRed);
			//toolbar.SetBackgroundColor ((Color)color.handle);

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			//FFont.Color.handle = toolbar.TintColor;

			NativeChanged ();
			Handle = toolbar;
		}
	}
    /*
	public partial class TToolButton: TComponent
	{
		public UIBarButtonItem barbuttonitem;

		protected override void CreateNonVisualHandle()
		{
			//Creates the native handle
			barbuttonitem = new UIBarButtonItem ();
			barbuttonitem.Title = "< Back";

			//Assign native handles to manage through the wrappers
			//FFont.handle = uitoolbar.Font;
			//FFont.Color.handle = uibarbuttonitem.TintColor;

			//NativeChanged ();
			Handle = barbuttonitem;
		}

		partial  void NativeOnClickAdd(EventHandler value)
		{
			barbuttonitem.Clicked+=value;
		}

		partial  void NativeOnClickRemove(EventHandler value)
		{
			barbuttonitem.Clicked-=value;
		}


		partial void NativeToolbarChanged(TToolbar AToolbar)
		{
			AToolbar.Buttons.Add(this);
			UIBarButtonItem[] items=new UIBarButtonItem[AToolbar.Buttons.Count];
			for (int i=0; i<=AToolbar.Buttons.Count-1; i++)
			{
				items[i]=(UIBarButtonItem)AToolbar.Buttons[i].Handle;
			}
			AToolbar.toolbar.Items=items;


			//	AToolbar.toolbar.item
			//barbuttonitem.
		}
	}
*/

    public class RecyclerHolder : RecyclerView.ViewHolder
    {
        public ImageView imImage;
        public TextView lbCaption;
        public TListItem liItem;
        public TCustomListView lvView;

        public RecyclerHolder(View ItemView) : base(ItemView)
        {
            //imImage = new ImageView(TApplication.context);
            lbCaption = (TextView)ItemView.FindViewById(105);
            imImage = (ImageView)ItemView.FindViewById(106);
        }
    }

    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private TCustomListView mOwner;

        private View CreateCardView(Context AContext)
        {
            CardView LCard = new CardView(AContext);

            // Set the CardView layoutParams
            LinearLayout.LayoutParams LParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                        
            LCard.LayoutParameters = LParams;

			// Set CardView corner radius
            LCard.Radius = 9;

			// Set cardView content padding
            LCard.SetContentPadding(15, 15, 15, 15);

			// Set a background color for CardView
			LCard.SetCardBackgroundColor(Color.ParseColor("#FFC6D6C3"));

            // Set the CardView maximum elevation
            LCard.MaxCardElevation = 15;

			// Set CardView elevation
			LCard.CardElevation = 9;

            LinearLayout LItemLayout = new LinearLayout(AContext);
            LItemLayout.Orientation = Orientation.Vertical;
            LCard.AddView(LItemLayout);

            // Initialize a new TextView to put in CardView
            TextView tv = new TextView(AContext);
            //tv.LayoutParameters = LParams;
            tv.Left = 10;
            tv.Top = 1;
            tv.SetWidth(130);
            tv.SetHeight(25);
			tv.Text = "CardView\nProgrammatically";
			//tv.SetTextSize(TypedValue.COMPLEX_UNIT_DIP, 30);
            tv.SetTextColor(Color.Red);
            tv.Id = 105;
            tv.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent); 
            tv.LayoutParameters.Height = 30;
            tv.LayoutParameters.Width = 130;

            ImageView im = new ImageView(AContext);
            im.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            im.LayoutParameters.Height = 160;
            im.LayoutParameters.Width = 130;
            im.Id = 106;

			// Put the TextView in CardView
			//LCard.AddView(tv);
            LItemLayout.AddView(im);
            LItemLayout.AddView(tv);

            return LCard;
        }

        public override int ItemCount => mOwner.Items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerHolder LHolder = holder as RecyclerHolder;

            LHolder.lbCaption.Text = mOwner.Items[position].Caption;
            LHolder.imImage.SetImageBitmap(mOwner.LargeImages.Items[mOwner.Items[position].ImageIndex].bitmap);

            LHolder.ItemView.SetOnClickListener(new ListViewClickListener());
            LHolder.ItemView.Tag = LHolder;
            LHolder.liItem = mOwner.Items[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View LView = CreateCardView(parent.Context);
            RecyclerHolder LHolder = new RecyclerHolder(LView);
            LHolder.lvView = mOwner;

            return LHolder;
        }

        public RecyclerAdapter(TCustomListView Owner)
        {
             mOwner = Owner;
        }
    }

    internal class ListViewClickListener: Java.Lang.Object, View.IOnClickListener
    {
        void View.IOnClickListener.OnClick(View aView)
        {
            var LHolder = aView.Tag as RecyclerHolder;
            var LItem = LHolder.liItem; 
            LHolder.lvView.DoSelectItem(LItem, true);
        }
    }

    public partial class TCustomListView : TCustomMultiSelectListControl
	{
        public RecyclerView mRecycler;
        private GridLayoutManager mLayout;
        private RecyclerAdapter mAdapter;

        private RecyclerAdapter mColumnsAdapter;

		protected override void CreateNativeHandle()
		{
            //Creates the native handle 
            mRecycler = new RecyclerView(TApplication.context);

            if (this.ViewStyle != TViewStyle.vsIcon && this.ViewStyle != TViewStyle.vsSmallIcon)
			{
                mLayout = new GridLayoutManager(TApplication.context, this.Columns.Count);
                mRecycler.SetLayoutManager(mLayout);
                mColumnsAdapter = new RecyclerAdapter(this);
                mRecycler.SetAdapter(mColumnsAdapter);
			}
			else
			{				
                mLayout = new GridLayoutManager(TApplication.context, 4 /*2*/);
				mRecycler.SetLayoutManager(mLayout);
				mAdapter = new RecyclerAdapter(this);
				mRecycler.SetAdapter(mAdapter);
			}
            NativeChanged();
            Handle = mRecycler;
		}

		partial void NativeChangeViewStyle()
		{
			CreateNativeHandle();
			ReloadData();
		}

		partial void ReloadData()
		{            
            
		}
	}

}
#endif
