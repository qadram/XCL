# radx
VCL-like cross-platform framework for Xamarin

The goal of this library is to mimmic VCL-style of development in Xamarin, providing a cross-platform solution to develop mobile apps.

It's in a very early stage, the basics are committed and allows you to create basic forms, show and close them, and include buttons, edits and labels.

| iOS  | Android |
| ------------- | ------------- |
| ![iOS](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/samples_ios.gif)  | ![Android](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/samples_android.gif)  |
| ![iOS](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/login_ios.gif)  | ![Android](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/login_android.gif)  |

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
![iOS](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/ios1.png)

And this is on Android
![Android](https://raw.githubusercontent.com/radxdev/radx/master/screenshots/android1.png)

## Globals
In order to replicate the global variables and functions, we are using a partial class named "_", so you can define static members on this class at any time. 

## Project structure
If you create a cross-platform app on Xamarin, you will get a solution with three projects, the portable one, one for iOS and another for Android.
