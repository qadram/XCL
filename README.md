# radx
VCL-like cross-platform framework for Xamarin

The goal of this library is to mimmic VCL-style of development in Xamarin, providing a cross-platform solution to develop mobile apps.

It's in a very early stage, the basics are committed and allows you to create basic forms, show and close them, and include buttons, edits and labels.

| iOS  | Android |
| ------------- | ------------- |
| ![iOS](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/samples_ios.gif)  | ![Android](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/samples_android.gif)  |

## Hello World
This is a sample Hello World, in which:
* A Button, an Edit and a Label are created, and put on the Form
* An event is attached to the Button, so, when clicked, the Label is set with the contents of the Edit
```
using System;
using System.Base;
using System.Classes;
using System.UITypes;
using Xcl.StdCtrls;
using Xcl.Forms;

namespace Unit1
{
	public class TForm1: TForm
	{
		public TButton Button1;
		public TEdit Edit1;
		public TLabel Label1;

		public TForm1 (TComponent AOwner):base(AOwner)
		{
		}

		public override void Loaded()
		{
			Button1 = TButton.Create (self);
			Edit1 = TEdit.Create (self);
			Label1 = TLabel.Create (self);

			Button1.Parent = self;
			Edit1.Parent = self;
			Label1.Parent = self;

			Button1.Top = 100;
			Button1.Left = 50;
			Button1.Height = 50;
			Button1.Color = TColor.clBlue;
			Button1.Caption = "Click here!!!";
			Button1.OnClick += Button1Click;

			Edit1.Left = 10;
			Edit1.Top = 40;
			Edit1.Width = 200;
			Edit1.Height = 40;
			Edit1.Text = "This is a test";	

			Label1.Left = 10;
			Label1.Top = 180;
			Label1.Width = 200;
			Label1.Height = 40;
			Label1.Text = "Label1";	

		}

		void Button1Click (object sender, EventArgs e)
		{
			Label1.Caption = Edit1.Text;
		}
	}
}
```
This is how it will look on iOS
![iOS](https://cloud.githubusercontent.com/assets/18068729/14943254/ebd3b146-0fd3-11e6-8288-3247af57a204.png)


And this is for Android
![Android](https://cloud.githubusercontent.com/assets/18068729/14943253/ebbd60d0-0fd3-11e6-99ff-bd814400e368.png)

## Globals
In order to replicate the global variables and functions, we are using a partial class named "_", so you can define static members on this class at any time. 

## Project structure
If you create a cross-platform app on Xamarin, you will get a solution with three projects, the portable one, one for iOS and another for Android.

## Creating forms on iOS
To create your forms, be sure to delete the storyboard that is added to the iOS project, and put this code on the AppDelegate

```
			Window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			_.Form1 = new TForm1 (_.Application);

			TApplication.LastViewController = _.Form1.handle;
			_.Application.MainForm = _.Form1;
			Window.RootViewController = _.Form1.handle;

			// make the window visible
			Window.MakeKeyAndVisible();
```
We will optimize this step so you have to write less code.

## Creating forms on Android
In Android, replace the OnCreate event handler of your MainActivity with this code

```
			TApplication.context = this.BaseContext;
			TApplication.MainActivity = this;

			_.Form1 = new TForm1 (_.Application);
			_.Application.MainForm = _.Form1;

			_.Form1.Show ();
```
We will optimize this step so you have to write less code.





