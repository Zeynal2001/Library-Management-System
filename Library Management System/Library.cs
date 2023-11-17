namespace Library_Management_System
{
    // Library sinifi
    // Bu sinif, kitabxana funksiyonallığını idarə edir və elementlərin əlavə edilməsi, göstərilməsi, verilməsi və axtarılması üçün metodlar təyin edir.
    public class Library
    {
        // Kitabxanadakı elementləri saxlamaq üçün LibraryItem tipində massiv yaradırıq.
        private LibraryItem[] _libraryItems;

        // Library sinifinin constructoru
        // Bu constructor, əvvəlcədən təyin edilmiş bir kitabxana obyektini yaratmağa kömək edir.
        public Library()
        {
            // Başlanğıc elementlərin yaradılması
            _libraryItems = new LibraryItem[]
            {

                new Book("Agatha Christie", "Murder on the Orient Express", new Date(1934), "Mystery"),
                new Book("George Orwell", "1984", new Date(1948), "Science Fiction"),
                new Book("Arthur Conan Doyle", "Sherlock Holmes", new Date(1887), "Mystery"),
                new Journal("The Economist", new Date(2023), "Magazine, Business"),
                new Journal("National Geographic", new Date(2023), "Magazine, Science")
            };
        }

        // Kitabxandakı elementləri konsolda göstərmək üçün metod
        public void DisplayLibraryItems()
        {
            Console.WriteLine("Elementlərə diqqətlə baxın. 5 Saniyə içində ekran təmizlənəcək.");

            Console.WriteLine("\nKitabxandakı elementlər:");
            foreach (var item in _libraryItems)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (item is Book kitab)
                {
                    Console.WriteLine($"Kitab: {kitab.Name} - Müəllif: {kitab.Author} - Janr: {kitab.Genre} - Tarix: {kitab.Date.Year}");
                }
                else if (item is Journal jurnal)
                {
                    Console.WriteLine($"Jurnal: {jurnal.Name} - Janr: {jurnal.Genre} - Tarix: {jurnal.Date.Year}");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Thread.Sleep(13000);
            Console.Clear();
        }

        // Kitabxanaya yeni element əlavə etmək üçün metod
        public void AddLibraryItem()
        {
            Console.Write("\nElement növünü seçin (Kitab, Jurnal və s.): ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string itemType = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Adı: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string itemName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Tarix - İl: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            int year = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Janr: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string genre = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            if (itemType.ToLower() == "kitab")
            {
                Console.Write("Müəllif: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string author = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                Array.Resize(ref _libraryItems, _libraryItems.Length + 1);
                _libraryItems[_libraryItems.Length - 1] = new Book(author, itemName, new Date(year), genre);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Kitab əlavə edildi.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (itemType.ToLower() == "jurnal")
            {
                Array.Resize(ref _libraryItems, _libraryItems.Length + 1);
                _libraryItems[_libraryItems.Length -1] = new Journal(itemName, new Date(year), genre);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Jurnal əlavə edildi.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Düzgün element növü daxil edilməyib.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Kitabxanadan kirayə element verilmək üçün metod
        public void LendItemToStudent()
        {
            try
            {
                // Kitabxandakı elementləri göstərmək
                DisplayLibraryItems();

                Console.Write("\nKirayə veriləcək elementin adını daxil edin: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string itemName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                bool found = false;

                // Elementin mövcud olduğunu yoxlamaq
                foreach (var item in _libraryItems)
                {
                    if (item.Name.ToLower() == itemName.ToLower() && item.IsAvailable)
                    {
                        found = true;

                        // Elementin tipinə görə əməliyyat yerinə yetirmək
                        if (item is Book kitab)
                        {
                            Console.WriteLine($"Kitab tapıldı: {kitab.Name} - Müəllif: {kitab.Author} - Janr: {kitab.Genre} - Tarix: {kitab.Date.Year}");
                            Console.Write("Tələbənin adını daxil edin: ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            string studentName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            // Burada tələbəyə kitab verilmə əməliyyatı yerinə yetirilir
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{kitab.Name} adlı kitab {studentName} adlı tələbəyə (kirayə) verildi.");
                            Console.ForegroundColor = ConsoleColor.White;
                            // Kitabxanadan elementi silmək
                            RemoveLibraryItem(item);
                            // Kitabın artıq verildiyini göstərmək üçün IsAvailable property-sini dəyişmək
                            kitab.IsAvailable = false;
                        }
                        else if (item is Journal jurnal)
                        {
                            Console.WriteLine($"Jurnal tapıldı: {jurnal.Name} - Janr: {jurnal.Genre} - Tarix: {jurnal.Date.Year}");
                            Console.Write("Tələbənin adını daxil edin: ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            string studentName = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            // Burada tələbəyə jurnal verilən əməliyyatı yerinə yetirilir
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{jurnal.Name} adlı jurnal {studentName} adlı tələbəyə verildi.");
                            Console.ForegroundColor = ConsoleColor.White;
                            // Kitabxanadan elementi silmək
                            RemoveLibraryItem(item);
                            // Jurnalın artıq verildiyini göstərmək üçün IsAvailable property-sini dəyişmək
                            jurnal.IsAvailable = false;
                        }
                    }
                }
                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Daxil etdiyiniz adla heç bir element tapılmadı və ya artıq verilib.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
               Thread.Sleep(5000);
               Console.Clear();
            }
        }

        // Kitabxanda axtarış üçün metod
        public void SearchLibrary()
        {
            Console.WriteLine("\nAxtardığınız elementin adını daxil edin: ");
            string searchName = Console.ReadLine();

            bool found = false;

            foreach (var item in _libraryItems)
            {
                if (item.Name.ToLower() == searchName.ToLower())
                {
                    found = true;

                    if (item is Book kitab)
                    {
                        Console.WriteLine($"Tapıldı: Kitab - Ad: {kitab.Name} - Müəllif: {kitab.Author} - Janr: {kitab.Genre} - Tarix: {kitab.Date.Year}");
                    }
                    else if (item is Journal jurnal)
                    {
                        Console.WriteLine($"Tapıldı: Jurnal - Ad: {jurnal.Name} - Janr: {jurnal.Genre} - Tarix: {jurnal.Date.Year}");
                    }
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Axtarışa uyğun element tapılmadı.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Kitabxanadan elementi silmək üçün metod
        private void RemoveLibraryItem(LibraryItem item)
        {
            // Verilən elementi kitabxanadan silmək üçün kod
            int indexToRomove = Array.IndexOf( _libraryItems, item);
            if (indexToRomove != -1)
            {
                // İndeksi silmək üçün Resize funksiyasına göndərək kitabxanadan elementi silirik
                Array.Resize(ref _libraryItems, _libraryItems.Length - 1);
            }
        }
    }
}

        //private void RemoveLibraryItem(LibraryItem item)
        //{
        //    // Verilən elementi kitabxanadan silmək üçün kod
        //    int indexToRemove = Array.IndexOf(_libraryItems, item);
        //    if (indexToRemove != -1)
        //    {
        //        LibraryItem[] newArray = new LibraryItem[_libraryItems.Length - 1];
        //        Array.Copy(_libraryItems, 0, newArray, 0, indexToRemove);
        //        Array.Copy(_libraryItems, indexToRemove + 1, newArray, indexToRemove, _libraryItems.Length - indexToRemove - 1);
        //        _libraryItems = newArray;
        //    }
        //}