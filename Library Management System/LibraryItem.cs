namespace Library_Management_System
{
    // LibraryItem sinifi
    // Bu sinif, bibliyotekada olan hər hansı bir elementin əsas xüsusiyyətlərini təsvir edir.
    public abstract class LibraryItem
    {
        // Elementin adı, tarixi, mövcudluğu və janrı kimi xüsusiyyətlər.
        public string Name { get; set; }
        public Date Date { get; set; }
        public bool IsAvailable { get; set; }
        public string Genre { get; set; }

        // LibraryItem sinifinin constructor.
        // Bu constructor, yeni bir LibraryItem obyekti yaratmağa və əsas xüsusiyyətlərini təyin etməyə kömək edir.
        public LibraryItem(string name, Date date, string genre)
        {
            // Verilənlər əsasında obyektin xüsusiyyətlərini təyin etmək.
            Name = name;
            Date = date;
            Genre = genre;
            IsAvailable = true; // Yeni yaradılan element default olaraq mövcuddur.
        }
    }
}

