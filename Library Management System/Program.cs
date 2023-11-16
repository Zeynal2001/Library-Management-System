using Library_Management_System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Programın əsas obyekti yaradılır və Run metodu çağrılır.
        Program program = new Program();
        program.Run();
        
    }

    void Run()
    {
        try
        {
            // İstifadəçinin doğrulanması üçün AuthenticateUser metodu çağrılır.
            bool isUserAuthenticated = AuthenticateUser();
            int loginAttempts = 0;
            Library library = new Library();

            // İstifadəçi doğrulanana qədər təkrarlanan bir döngü.
            while (!isUserAuthenticated)
            {
                Console.WriteLine("Daxil etdiyiniz istifadəçi adı və ya şifrə yalnışdır!");
                loginAttempts++;

                // 5 dəfə yanlış giriş etdikdə proqramın bağlanması.
                if (loginAttempts >= 5)
                {
                    Console.WriteLine("Siz 5 dəfə yanlış istifadəçi adı və ya şifrə daxil etdiniz. Proqram bağlanır.");
                    return;
                }

                isUserAuthenticated = AuthenticateUser();
            }

            // Proqramın menyu funksiyaları üçün sonsuz döngü yaradılır. 
            while (true)
            {
                // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Kitabxanadakı elementlərin siyahısının göstərilməsi.
                        library.DisplayLibraryItems();
                        break;
                    case "2":
                        // Element əlavə etmə funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        AddLibraryItemWithExceptionHandling(library);
                        break;
                    case "3":
                        // Tələbəyə kitab vermə funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        LendItemToStudentWithExceptionHandling(library);
                        break;
                    case "4":
                        // Kitabxanada axtarış funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        SearchLibraryWithExceptionHandling(library);
                        break;
                    case "5":
                        // Proqramın bağlanması.
                        Console.WriteLine("Proqram bağlanır.");
                        return;
                    default:
                        // Yanlış seçim halında istifadəçiyə bildiriş göstərilir.
                        Console.WriteLine("Yanlış seçim! Zəhmət olmasa düzgün əməliyyatı seçin.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
        finally
        {
            // Bura əlavə təmizləmə və ya əlavə tədbirlər əlavə edilə bilər.
        }
    }

    public bool AuthenticateUser()
    {
        try
        {
            // İstifadəçi adı və şifrəni almaq üçün istifadəçiyə soruşulur.
            Console.Write("İstifadəçi adı: ");
            string username = Console.ReadLine();
            Console.Write("Şifrə: ");
            string password = Console.ReadLine();

            // Daxil edilmiş məlumatların adminin məlumatları ilə uyğunluğunu yoxlamaq.
            if (username == "Zeynal" && password == "Zeynal123")
            {
                Console.WriteLine("Giriş uğurla başa çatdı!");
                return true;
            }
            else
            {
                Console.WriteLine("Giriş uğursuz oldu. Yenidən cəhd edin.");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Əgər xəta baş verərsə istifadəçiyə bildiriş göstərilir.
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            return false;
        }
    }

    public void AddLibraryItemWithExceptionHandling(Library library)
    {
        try
        {
            // Kitabxanaya yeni element əlavə etmə funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.AddLibraryItem();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
    }

    public void LendItemToStudentWithExceptionHandling(Library library)
    {
        try
        {
            // Tələbəyə kitab vermə funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.LendItemToStudent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
    }

    public void SearchLibraryWithExceptionHandling(Library library)
    {
        try
        {
            // Kitabxanada axtarış funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.SearchLibrary();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
    }

    public void DisplayMenu()
    {
        // Proqramın əsas menyu seçimlərinin göstərilməsi:
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n-----------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Kitabxanadakı element siyahısı");
        Console.WriteLine("2. Element əlavə etmək");
        Console.WriteLine("3. Tələbəyə (kirayə) kitab vermək");
        Console.WriteLine("4. Kitabxanada axtarış etmək");
        Console.WriteLine("5. Proqramdan çıxmaq");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("-----------------------------------");
        Console.Write("Seçiminizi daxil edin: ");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
