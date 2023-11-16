namespace Library_Management_System
{
    // Journal sinifi
    // Bu sinif, LibraryItem sinifindan miras alaraq jurnal elementinin xüsusiyyətlərini əlavə edir.
    public class Journal : LibraryItem
    {
        // Journal sinifinin constructoru.
        // Bu constructor, yeni bir Journal obyekti yaratmağa və əsas xüsusiyyətlərini təyin etməyə kömək edir.
        public Journal(string name, Date date, string genre)
            : base(name, date, genre)
        {
            // Journal sinifı üçün əlavə xüsusiyyətlər yoxdur, bu səbəbdə boş qalır.
        }
    }
}
