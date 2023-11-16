namespace Library_Management_System
{
    // Book sinifi
    // Bu sinif, LibraryItem sinifindan miras alaraq kitab elementinin xüsusiyyətlərini əlavə edir.
    public class Book : LibraryItem
    {
        // Kitabın müəllifi kimi əlavə xüsusiyyət.
        public string Author { get; set; }

        // Book sinifinin constructoru.
        // Bu constructor, yeni bir Book obyekti yaratmağa və əsas xüsusiyyətlərini təyin etməyə kömək edir.
        public Book(string author, string name, Date date, string genre)
            : base(name, date, genre)
        {
            // Verilənlər əsasında obyektin xüsusiyyətlərini təyin etmək.
            Author = author;
        }
    }
}
