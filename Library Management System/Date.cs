namespace Library_Management_System
{
    // Date sinifi
    // Bu sinif, tarix məlumatını saxlamaq üçün istifadə olunur.
    public class Date
    {
        // Il, ay, və gün kimi tarix xüsusiyyətlərini saxlaya bilərik.
        // H
        public int Year { get; set; }


        // Date sinifinin constructoru.
        // Bu constructor, yeni bir Date obyekti yaratmağa və əsas xüsusiyyətlərini təyin etməyə kömək edir.
        public Date(int year)
        {
            Year = year;
            
        }
    }
}
