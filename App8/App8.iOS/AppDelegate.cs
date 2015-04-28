using System.Collections.Generic;
using System.Linq;
using AddressBook;
using AddressBookUI;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace App8.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Global.Doer = new iOSDoer();
            Forms.Init();
            LoadApplication(new App());
            

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSDoer : IDo
    {
        public void ShowContact(NavigationPage page)
        {
            var newPersonController = new ABNewPersonViewController();
            var person = new ABPerson();
            person.FirstName = "John";
            person.LastName = "Doe";


            newPersonController.DisplayedPerson = person;
            var controller = page.CreateViewController();

            //controller.NavigationController is null
            controller.NavigationController.PushViewController(newPersonController, true);            
        }

        public IList<string> GetAllNames()
        {
            var people = new ABAddressBook().GetPeople();
            return people.Select(p => p.FirstName).ToList();
        }
    }
}
