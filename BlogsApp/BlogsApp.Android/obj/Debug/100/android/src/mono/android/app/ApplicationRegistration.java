package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("BlogsApp.Droid.MainApplication, BlogsApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64c809c936d7ef4c29.MainApplication.class, crc64c809c936d7ef4c29.MainApplication.__md_methods);
		
	}
}
