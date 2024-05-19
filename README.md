# flashcard_mobile/ FLASH it (tentative lool)
### NOTE: if an issue such as "InitializeComponent() does not exist in this context" or something related to that, just clean and rebuild the project. If issues persist, restart your Visual Studio since this has been a common problem.

### Flow:
- user & pass: admin (for easy access when debugging)
- register first then login using the newly registered acc (this is because the data is only exclusive per session 

`Converter`
- defined for page traversals (used in `Register/LoginPage.xaml`).

`Models`
- consists of classes used in the project (User, Deck, & Card).

`Services`
- `DataService.cs` & `DialogService.cs` were used for data handling and alter systems such as pop ups and the like.
- `DataService.cs` consists of the Disctionary the Users and List of Decks are stored per session (volatile memory so it'll disappear at the end of execution).
- logic for adding and getting user data is found here.
- CRUD operations on decks are also found here (will need revisions for whoever is in charge of creating, editing, and deleting a deck)

`ViewModels`
- instantiated in its corresponding `.xaml.cs` file.
- from my understanding, its like the middle man between the page `.xaml.cs` and `.xaml`.
- referencing in it's corresponding `.xaml.cs` file: `using flashcard_mobile.ViewModels;`
- referencing in it's corresponding `.xaml` file: `xmlns:viewModels="clr-namespace:flashcard_mobile.ViewModels"`

`Views`
- the actual pages
- `AccountPopup.xaml` is tied to the `My Account` text in the homepage, it's a drop down menu that should show `View Account`, `Edit Account`, and `Logout`.
- `Logout` already works, `View Account`, and `Edit Account` no ra and I didnt put any linkage lng sah.

`App.xaml.cs`
- Initialized `DataService` here

`AppShell.xaml`
- this is where the routes should be declared
- Ex: `<ShellContent Route="login" ContentTemplate="{DataTemplate views:LoginPage}" />`
- How the routes were used: `await Shell.Current.GoToAsync("//login");`
