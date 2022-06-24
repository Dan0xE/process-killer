//list all the programms currently running on the computer
//using the Process class
#pragma warning disable CA1416 // Rethrow to preserve stack details
#pragma warning restore CS8600 // Rethrow to preserve stack details

using System.Diagnostics;

PerformanceCounter cpuUsage;
PerformanceCounter ramUsage;

cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
ramUsage = new PerformanceCounter("Memory", "Available MBytes");


Process[] process = Process.GetProcesses();

Console.Clear();

Console.WriteLine("Currently there are " + process.Length + " programms running on the computer");

Console.WriteLine("List of all the programms currently running on the computer");
Console.WriteLine("-------------------------------------------------------");

//write out all the programms currently running on the computer

//loop through all the programms and store them in the process array

foreach (Process p in process)
{
    try
    {
        //write out all process with the cpu usage and ram usage
        Console.WriteLine("Process Name: " + p.ProcessName + " - CPU Usage: [" + cpuUsage.NextValue() + "%] RAM Usage: [" + ramUsage.NextValue() + "MB]");
    } catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}


//get cpu ussage in percentage



Console.WriteLine("-------------------------------------------------------");

//ask the user to enter the name of the programm he/she wants to exit


//find the programm the user wants to exit


var Exit = false;


while (!Exit)
{
    Console.WriteLine("Enter the name of the programm you want to exit");
    //make string not null
    string programm = Console.ReadLine();
    var found = false;
    try
    {
        {
            foreach (Process p in process)
            {
                try
                {
                    if (p.ProcessName == programm && programm != "" && programm != " " && programm != null)
                    {
                        p.Kill();
                        found = true;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            if(found) {
                Console.WriteLine("The programm " + programm + " has been closed");
            }
            else {
                Console.WriteLine("The programm " + programm + " could not be found");
            }


            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Do you want to exit? (y/n)");
            try
            {
                string answer = Console.ReadLine();
                var exitNow = false;
                while (!exitNow)
                {
                    try
                    {
                        if (answer == "y")
                        {
                            Exit = true;
                            exitNow = true;
                        }
                        else if (answer == "n")
                        {
                            exitNow = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter y or n");
                            answer = Console.ReadLine();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}