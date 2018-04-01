using Android.Runtime;
using System;
using System.Linq;
using Java.Interop;


namespace Xamarin.Facebook.Share.Widget
{
    public partial class DeviceShareButton
    {
        static IntPtr id_setEnabled_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='DeviceShareButton']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register ("setEnabled", "(Z)V", "")]
        public unsafe void SetEnabled (bool enabled)
        {
            if (id_setEnabled_Z == IntPtr.Zero)
                id_setEnabled_Z = JNIEnv.GetMethodID (class_ref, "setEnabled", "(Z)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (enabled);
                JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setEnabled_Z, __args);
            } finally {
            }
        }
    }

    public partial class ShareButtonBase
    {
        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler ()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z (IntPtr jnienv, IntPtr native__this, bool enabled)
        {
            global::Xamarin.Facebook.Share.Widget.ShareButtonBase __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Widget.ShareButtonBase> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled (enabled);
        }
#pragma warning restore 0169

        static IntPtr id_setEnabled_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='ShareButtonBase']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register ("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled (bool enabled)
        {
            if (id_setEnabled_Z == IntPtr.Zero)
                id_setEnabled_Z = JNIEnv.GetMethodID (class_ref, "setEnabled", "(Z)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (enabled);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setEnabled_Z, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEnabled", "(Z)V"), __args);
            } finally {
            }
        }
    }

    public partial class AppInviteDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers ()
		{
			return OrderedModeHandlers.ToList();
		}
	}

	public partial class CreateAppGroupDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}	
	}

	public partial class GameRequestDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}	
	}

	public partial class JoinAppGroupDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}	
	}

	public partial class MessageDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}	
	}
}

namespace Xamarin.Facebook.Share
{
    public partial class DeviceShareDialog
	{
		protected override global::System.Collections.Generic.IList<global::Xamarin.Facebook.Internal.FacebookDialogBase.ModeHandler> _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}	
	}
}

namespace Xamarin.Facebook.Share.Model
{
    public partial class AppInviteContent
    {
        public partial class Builder
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.model']/class[@name='AppInviteContent.Builder']/method[@name='readFrom' and count(parameter)=1 and parameter[1][@type='P']]"
            [Register("readFrom", "(Lcom/facebook/share/model/AppInviteContent;)Lcom/facebook/share/model/AppInviteContent$Builder;", "GetReadFrom_Lcom_facebook_share_model_AppInviteContent_Handler")]
            public virtual unsafe global::Java.Lang.Object ReadFrom(global::Java.Lang.Object p0)
            {
                const string __id = "readFrom.(Lcom/facebook/share/model/AppInviteContent;)Lcom/facebook/share/model/AppInviteContent$Builder;";
                IntPtr native_p0 = JNIEnv.ToLocalJniHandle(p0);
                try
                {
                    JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                    __args[0] = new JniArgumentValue(native_p0);
                    var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
                    return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
                }
                finally
                {
                    JNIEnv.DeleteLocalRef(native_p0);
                }
            }
        }
    }
}