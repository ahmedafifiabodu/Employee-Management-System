namespace Task_10
{
    internal class Program
    {
        private static void Main()
        {
            #region Entrance

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.SetCursorPosition((Console.WindowWidth - "Welcome to EGH.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to EGH.");
            Console.WriteLine("\n");
            Console.SetCursorPosition((Console.WindowWidth - "Press any key to contiue.".Length) / 2, Console.CursorTop);
            Console.WriteLine("Press any key to contiue.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            #endregion Entrance

            #region Manual Test

            /*
            Department department = new(1, "Engineering");
            department.AddStaff(new(10, new DateTime(1964, 10, 1), 2));
            department.AddStaff(new(11, new DateTime(1980, 5, 3), 1));

            //department.DisplayStaff();
            //department.Staffs[0].EndOfYearOperation();
            //Console.WriteLine( department.Staffs[0].EmployeeID);
            //department.Staffs[1].RequestVacation(new DateTime(2000, 1, 1), new DateTime(2000, 2, 2));

            Console.WriteLine("***************");

            //department.DisplayStaff();

            //Console.WriteLine("***************");

            //Club newClub = new(50, "Buff");
            //newClub.AddMember(new(10, new DateTime(1964, 10, 1), 2));
            //newClub.AddMember(new(11, new DateTime(1980, 5, 3), 1));
            //newClub.ClubMembersList[1].RequestVacation(new DateTime(2000, 1, 1), new DateTime(2000, 2, 2));
            //newClub.ClubMembersList[1].RequestVacation(new DateTime(2000, 1, 1), new DateTime(2000, 2, 2));
            //newClub.DisplayStaff();

            //Console.WriteLine("***************");

            //SalesPerson emp = new(99, new DateTime(2000, 1, 1));
            //department.AddStaff(emp);
            //department.DisplayStaff();

            //Console.WriteLine("***************");

            //emp.CheckEmployeeQuota(emp.Quota, 100);
            //department.DisplayStaff();

            //Console.WriteLine("***************");

            //BoardMember BM = new(55, new DateTime(2001, 5, 6));
            //department.AddStaff(BM);
            //department.DisplayStaff();

            //Console.WriteLine("***************");

            //BM.RequestVacation(new DateTime(2001, 5, 6), new DateTime(2001, 5, 9));
            //BM.EndOfYearOperation();
            //BM.Resign();
            //department.DisplayStaff();
            */

            #endregion Manual Test

            #region Interface

            while (true)
            {
                if (Generic.departments.Count == 0 && Generic.clubs.Count == 0)
                {
                    Generic.MessageOperation(
                        "Select:\n" +
                        "\t1. Add new department.\n" +
                        "\t2. Add new club.\n" +
                        "\t3. Quit.\n", ConsoleColor.Yellow, false, false);

                    char key = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (key)
                    {
                        case '1':
                            Generic.AddEntity(Generic.departments, "department");
                            break;

                        case '2':
                            Generic.AddEntity(Generic.clubs, "Club");
                            break;

                        case '3':
                            return;

                        default:
                            Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                            break;
                    }
                }
                else if (Generic.departments.Count >= 0 || Generic.clubs.Count >= 0)
                {
                    Generic.MessageOperation(
                        "Select:\n" +
                        "\t1. Add new Department.\n" +
                        "\t2. Add new Club.\n" +
                        "\t3. Add new Employee.\n" +
                        "\t4. Display Employee.\n" +
                        "\t5. Check Sales Employee Quote.\n" +
                        "\t6. Request Resign for Board Employee.\n" +
                        "\t7. Request a vacation.\n" +
                        "\t8. End Of Year Update.\n" +
                        "\t9. Quit.",
                        ConsoleColor.Yellow, false, false);

                    char key = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (key)
                    {
                        case '1':
                            Generic.AddEntity(Generic.departments, "department");
                            break;

                        case '2':
                            Generic.AddEntity(Generic.clubs, "Club");
                            break;

                        case '3':

                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                            Generic.Display(Generic.departments, "Department", true);
                            Generic.Display(Generic.clubs, "Club", true);

                            Generic.MessageOperation(
                                "\nSelect: \n" +
                                "\t1. Add employee to a Department.\n" +
                                "\t2. Add employee to a Club.\n" +
                                "\t3. Return Back.\n" +
                                "\t4. Quit.",
                                ConsoleColor.Yellow, false, false);

                            key = Console.ReadKey().KeyChar;
                            Console.Clear();

                            switch (key)
                            {
                                case '1':

                                    Generic.Display(Generic.departments, "Department", true);
                                    Generic.Display(Generic.clubs, "Club", true);

                                    Generic.MessageOperation(
                                        "\nSelect: \n" +
                                        "\t1. Add a Normal Employee.\n" +
                                        "\t2. Add a Sales Employee.\n" +
                                        "\t3. Add a Board Employee.\n" +
                                        "\t4. Return Back.\n" +
                                        "\t5. Quit.",
                                        ConsoleColor.Yellow, false, false);

                                    key = Console.ReadKey().KeyChar;
                                    Console.Clear();

                                    switch (key)
                                    {
                                        case '1':
                                            Generic.AddEmployee(Generic.departments, "Department", 0);
                                            break;

                                        case '2':
                                            Generic.AddEmployee(Generic.departments, "Department", 1);
                                            break;

                                        case '3':
                                            Generic.AddEmployee(Generic.departments, "Department", 2);
                                            break;

                                        case '4':
                                            break;

                                        case '5':
                                            return;

                                        default:
                                            Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                            break;
                                    }
                                    break;

                                case '2':

                                    Generic.Display(Generic.departments, "Department", true);
                                    Generic.Display(Generic.clubs, "Club", true);

                                    Generic.MessageOperation(
                                        "\nSelect: \n" +
                                        "\t1. Add a Normal Employee.\n" +
                                        "\t2. Add a Sales Employee.\n" +
                                        "\t3. Add a Board Employee.\n" +
                                        "\t4. Return Back.\n" +
                                        "\t5. Quit.",
                                        ConsoleColor.Yellow, false, false);

                                    key = Console.ReadKey().KeyChar;
                                    Console.Clear();

                                    switch (key)
                                    {
                                        case '1':
                                            Generic.AddEmployee(Generic.clubs, "Club", 0);
                                            break;

                                        case '2':
                                            Generic.AddEmployee(Generic.clubs, "Club", 1);
                                            break;

                                        case '3':
                                            Generic.AddEmployee(Generic.clubs, "Club", 2);
                                            break;

                                        case '4':
                                            break;

                                        case '5':
                                            return;

                                        default:
                                            Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                            break;
                                    }
                                    break;

                                case '3':
                                    break;

                                case '4':
                                    return;

                                default:
                                    Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                    break;
                            }
                            break;

                        case '4':

                            Generic.MessageOperation(
                                "Select:\n" +
                                "\t1. Display the department employee.\n" +
                                "\t2. Display the club employee.\n" +
                                "\t3. Display the entire structure.\n" +
                                "\t4. Return Back.\n" +
                                "\t5. Quit.\n"
                                , ConsoleColor.Yellow, false, false);

                            key = Console.ReadKey().KeyChar;
                            Console.Clear();

                            switch (key)
                            {
                                case '1':
                                    Generic.Display(Generic.departments, "Department", true);
                                    break;

                                case '2':
                                    Generic.Display(Generic.clubs, "Club", true);
                                    break;

                                case '3':
                                    Generic.Display(Generic.departments, "Department", true);
                                    Generic.Display(Generic.clubs, "Club", true);
                                    break;

                                case '4':
                                    break;

                                case '5':
                                    return;

                                default:
                                    Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                    break;
                            }
                            break;

                        case '5':
                            Generic.CheckQuota();
                            break;

                        case '6':

                            Generic.MessageOperation(
                               "Select:\n" +
                               "\t1. Request Resign from a department.\n" +
                               "\t2. Request Resign from a club.\n" +
                               "\t3. Return Back.\n" +
                               "\t4. Quit.\n"
                               , ConsoleColor.Yellow, false, false);

                            key = Console.ReadKey().KeyChar;
                            Console.Clear();

                            switch (key)
                            {
                                case '1':
                                    Generic.RequestResign(Generic.departments, "Department");
                                    break;

                                case '2':
                                    Generic.RequestResign(Generic.clubs, "Club");
                                    break;

                                case '3':
                                    break;

                                case '4':
                                    return;

                                default:
                                    Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                    break;
                            }
                            break;

                        case '7':
                            Generic.Display(Generic.departments, "Department", true);
                            Generic.Display(Generic.clubs, "Club", true);
                            Generic.MessageOperation(
                                "Select:\n" +
                                "\t1. Request a vacation in a department.\n" +
                                "\t2. Request a vacation in a club.\n" +
                                "\t3. Return Back.\n" +
                                "\t4. Quit.\n"
                                , ConsoleColor.Yellow, false, false);

                            key = Console.ReadKey().KeyChar;
                            Console.Clear();

                            switch (key)
                            {
                                case '1':
                                    Generic.RequestVacation(Generic.departments, "Department");
                                    break;

                                case '2':
                                    Generic.RequestVacation(Generic.clubs, "Club");
                                    break;

                                case '3':
                                    break;

                                case '4':
                                    return;

                                default:
                                    Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                                    break;
                            }
                            break;

                        case '8':
                            Generic.EndOfTheYearUpdate();
                            break;

                        case '9':
                            return;

                        default:
                            Generic.MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                            break;
                    }
                }
            }

            #endregion Interface
        }
    }
}