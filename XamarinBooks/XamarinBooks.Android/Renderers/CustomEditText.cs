using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBooks.Droid.Renderers;
using XamarinBooks.UI.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEditText))]
namespace XamarinBooks.Droid.Renderers
{
	public class CustomEditText : EntryRenderer
	{
		public CustomEditText(Context context) : base(context)
		{

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Background = Context.GetDrawable(Resource.Drawable.border_shape);
				Control.SetPadding(25,0,25,0);
				Drawable icon = Context.GetDrawable(Resource.Drawable.search);
				Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(icon, null, null, null);

				int padding = (int)(25 * Resources.DisplayMetrics.Density);
				Control.CompoundDrawablePadding = 10;
			}
		}
	}
}