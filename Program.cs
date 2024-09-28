using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Vet Hospital Application!");

            // Inicializoj userRepository
            var userRepository = new UserRepository();
            // Inicializoj patientRepository
            var patientRepository = new PatientRepository();
            // Inicializoj medicationRepository
            var medicationRepository = new MedicationRepository();
            // Inicializoj medicalRecordRepository
            var medicalRecordRepository = new MedicalRecordRepository();
            // Inicializoj appointmentRepository
            var appointmentRepository = new AppointmentRepository();
            // Inicializoj BAL file per storeprocedures
            var bal = new BAL.BAL();
            // Shfaqja e menuse qe do i dale perdoruesit .
            List<string> menuItems = new List<string>
        {
                "1. View Users",
                "2. Add User",
                "3. Update User",
                "4. Delete User",
                "5. View Patients",
                "6. Add Patients",
                "7. Update Patients",
                "8. Delete Patients",
                "9. View Medications",
                "10. Add Medication",
                "11. Update Medication",
                "12. Delete Medication",
                "13. View Medical Record",
                "14. Add Medical Record",
                "15. Update Medical Record",
                "16. Delete Medical Record",
                "17. View Appointment",
                "18. Add Appointment",
                "19. Update Appointment",
                "20. Delete Appointment",
                "21. Get Patients by User",
                "22. Get Appointments by Patient",
                "23. Get Medical Records by Patient",
                "24. Exit"
        };

            DisplayMenu(menuItems, userRepository, patientRepository, medicationRepository, medicalRecordRepository, appointmentRepository, bal);
        }
        //metoda per te shfaqur menune
        static void DisplayMenu(List<string> menuItems, UserRepository userRepository, PatientRepository patientRepository, MedicationRepository medicationRepository, MedicalRecordRepository medicalRecordRepository, AppointmentRepository appointmentRepository, BAL.BAL bal)
        {
            Console.WriteLine("Main Menu:");
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }
            // Merr kerkesen e perdoruesit per menune me lart me readline
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            // Procesohet kerkesa e perdoruesit me lart.
            switch (input)
            {
                //shfaqja e case me funksionet qe therrasin secila.
                case "1":
                    ViewUsers(userRepository);
                    break;
                case "2":
                    AddUser(userRepository);
                    break;
                case "3":
                    UpdateUser(userRepository);
                    break;
                case "4":
                    DeleteUser(userRepository);
                    break;
                case "5":
                    ViewPatients(patientRepository);
                    break;
                case "6":
                    AddPatient(patientRepository);
                    break;
                case "7":
                    UpdatePatient(patientRepository);
                    break;
                case "8":
                    DeletePatient(patientRepository);
                    break;
                case "9":
                    ViewMedications(medicationRepository);
                    break;
                case "10":
                    AddMedication(medicationRepository);
                    break;
                case "11":
                    UpdateMedication(medicationRepository);
                    break;
                case "12":
                    DeleteMedication(medicationRepository);
                    break;
                case "13":
                    ViewMedicalRecords(medicalRecordRepository);
                    break;
                case "14":
                    AddMedicalRecord(medicalRecordRepository);
                    break;
                case "15":
                    UpdateMedicalRecord(medicalRecordRepository);
                    break;
                case "16":
                    DeleteMedicalRecord(medicalRecordRepository);
                    break;
                case "17":
                    ViewAppointments(appointmentRepository);
                    break;
                case "18":
                    AddAppointment(appointmentRepository);
                    break;
                case "19":
                    UpdateAppointment(appointmentRepository);
                    break;
                case "20":
                    DeleteAppointment(appointmentRepository);
                    break;
                case "21":
                    GetPatientsByUser(bal);
                    break;
                case "22":
                    GetAppointmentsByPatient(bal);
                    break;
                case "23":
                    GetMedicalRecordsByPatient(bal);
                    break;
                case "24":
                    Console.WriteLine("Exiting application...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            DisplayMenu(menuItems, userRepository, patientRepository, medicationRepository, medicalRecordRepository, appointmentRepository, bal);
        }

        //Me poshte eshte zhvillimi i metodave qe jane vendosur me siper per secilen kam vendosur try catch.
        static void ViewUsers(UserRepository userRepository)
        {
            try
            {// Me funskionin Getall merr te gjithe perdoruesit qe jane ne databaze.
                var users = userRepository.GetAll();

                // Keto zhvillohet shfaqja e users me foreach.
                Console.WriteLine("Users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Name: {user.UserName}, Email: {user.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddUser(UserRepository userRepository)
        {
            try
            {

                //shtimi sipas rradhes i te dhenave te reja ne databzes per nje user te ri
                Console.Write("Enter username: ");
                string userName = Console.ReadLine();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                Console.Write("Enter usertype: ");
                long userType = Convert.ToInt32(Console.ReadLine());
                //perdorimi i add qe eshte krijuar ne file tjeter
                userRepository.Add(new User { UserName = userName, Email = email, Password = password, UserType = userType });
                Console.WriteLine("User added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdateUser(UserRepository userRepository)
        {
            try
            {
                //kerkohet nga perdoruesi id qe do ndryshoje
                Console.Write("Enter user ID to update: ");
                long userId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i getbyid qe eshte krijuar ne file tjeter.
                var user = userRepository.GetById(userId);
                //kontrollohet nese nuk eshte null.
                if (user != null)
                {
                    Console.Write("Enter new username: ");
                    user.UserName = Console.ReadLine();
                    Console.Write("Enter new email: ");
                    user.Email = Console.ReadLine();
                    Console.Write("Enter new password: ");
                    user.Password = Console.ReadLine();
                    Console.Write("Enter new user type: ");
                    user.UserType = Convert.ToInt32(Console.ReadLine());
                    //perdorimi i update qe eshte krijuar ne file tjeter.
                    userRepository.Update(user);
                    Console.WriteLine("User updated successfully.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeleteUser(UserRepository userRepository)
        {
            try
            {
                //kerkohet nga perdoruesi id qe do fshije
                Console.Write("Enter user ID to delete: ");
                long userId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i delete qe eshte krijuar ne file tjeter.
                userRepository.Delete(userId);
                Console.WriteLine("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ViewPatients(PatientRepository patientRepository)
        {
            try
            {
                // Me funskionin Getall merr te gjithe pacientet qe jane ne databaze.
                var patients = patientRepository.GetAll();

                // Realizohet shfaqja e patients me foreach
                Console.WriteLine("Patients:");
                foreach (var patient in patients)
                {
                    Console.WriteLine($"Patient ID: {patient.PatientId}, Name: {patient.PatientName}, Age: {patient.Age}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddPatient(PatientRepository patientRepository)
        {
            try
            {//shtimi sipas rradhes i te dhenave te reja ne databazes per nje patient te ri
                Console.Write("Enter patient name: ");
                string patientName = Console.ReadLine();
                Console.Write("Enter age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter weight: ");
                int weight = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter species: ");
                string species = Console.ReadLine();
                Console.Write("Enter user ID: ");
                long userId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i add qe eshte krijuar ne file tjeter

                patientRepository.Add(new Patient { PatientName = patientName, Age = age, Weight = weight, Species = species, UserId = userId });
                Console.WriteLine("Patient added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdatePatient(PatientRepository patientRepository)
        {
            try
            {//kerkohet nga perdoruesi id qe do ndryshoje
                Console.Write("Enter patient ID to update: ");
                long patientId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i getbyid qe eshte krijuar ne file tjeter.

                var patient = patientRepository.GetById(patientId);
                //kontrollohet nese nuk eshte null.

                if (patient != null)
                {
                    Console.Write("Enter new patient name: ");
                    patient.PatientName = Console.ReadLine();
                    Console.Write("Enter new age: ");
                    patient.Age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new weight: ");
                    patient.Weight = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new species: ");
                    patient.Species = Console.ReadLine();
                    //perdorimi i update qe eshte krijuar ne file tjeter.

                    patientRepository.Update(patient);
                    Console.WriteLine("Patient updated successfully.");
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeletePatient(PatientRepository patientRepository)
        {
            try
            {             //kerkohet nga perdoruesi id qe do fshije

                Console.Write("Enter patient ID to delete: ");
                long patientId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i delete qe eshte krijuar ne file tjeter.

                patientRepository.Delete(patientId);
                Console.WriteLine("Patient deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ViewMedications(MedicationRepository medicationRepository)
        {

            try
            {  // Me funskionin Getall merr te gjithe medications qe jane ne databaze.
                var medications = medicationRepository.GetAll();

                // Realizohet shfaqja e medications me foreach
                Console.WriteLine("Medications:");
                foreach (var medication in medications)
                {
                    Console.WriteLine($"Medication ID: {medication.MedicationId}, Name: {medication.MedicationName}, Price: {medication.MedicationSellPrice}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddMedication(MedicationRepository medicationRepository)
        {
            try
            { //shtimi sipas rradhes i te dhenave te reja ne databazes per nje medication te ri
                Console.Write("Enter medication name: ");
                string medicationName = Console.ReadLine();
                Console.Write("Enter medication description: ");
                string medicationDesc = Console.ReadLine();
                Console.Write("Enter medication sell price: ");
                decimal medicationSellPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter quantity: ");
                long quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter dosage: ");
                int dosage = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter medication purchase price: ");
                decimal medicationPurchasePrice = Convert.ToDecimal(Console.ReadLine());
                //perdorimi i add qe eshte krijuar ne file tjeter
                medicationRepository.Add(new Medication { MedicationName = medicationName, MedicationDescription = medicationDesc, MedicationSellPrice = medicationSellPrice, Quantity = quantity, Dosage = dosage, MedicationPurchasePrice = medicationPurchasePrice });
                Console.WriteLine("Medication added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdateMedication(MedicationRepository medicationRepository)
        {
            try
            { //kerkohet nga perdoruesi id qe do ndryshoje
                Console.Write("Enter medication ID to update: ");
                long medicationId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i getbyid qe eshte krijuar ne file tjeter.
                var medication = medicationRepository.GetById(medicationId);
                //kontrollohet nese nuk eshte null.
                if (medication != null)
                {
                    Console.Write("Enter new medication name: ");
                    medication.MedicationName = Console.ReadLine();
                    Console.Write("Enter new medication description: ");
                    medication.MedicationDescription = Console.ReadLine();
                    Console.Write("Enter new medication sell price: ");
                    medication.MedicationSellPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter new quantity: ");
                    medication.Quantity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new dosage: ");
                    medication.Dosage = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new medication purchase price: ");
                    medication.MedicationPurchasePrice = Convert.ToDecimal(Console.ReadLine());
                    //perdorimi i update qe eshte krijuar ne file tjeter.
                    medicationRepository.Update(medication);
                    Console.WriteLine("Medication updated successfully.");
                }
                else
                {
                    Console.WriteLine("Medication not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeleteMedication(MedicationRepository medicationRepository)
        {
            try
            { //kerkohet nga perdoruesi id qe do fshije
                Console.Write("Enter medication ID to delete: ");
                long medicationId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i delete qe eshte krijuar ne file tjeter.
                medicationRepository.Delete(medicationId);
                Console.WriteLine("Medication deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ViewMedicalRecords(MedicalRecordRepository medicalRecordRepository)
        {
            try
            {
                // Me funskionin Getall merr te gjithe medical records qe jane ne databaze.
                var medicalRecords = medicalRecordRepository.GetAll();

                // Realizohet shfaqja e medical records me foreach
                Console.WriteLine("Medical Records:");
                foreach (var record in medicalRecords)
                {
                    Console.WriteLine($"Record ID: {record.RecordId}, Patient ID: {record.PatientId}, Diagnosis: {record.Diagnosis}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ViewAppointments(AppointmentRepository appointmentRepository)
        {
            try
            { // Me funskionin Getall merr te gjithe appointments qe jane ne databaze.
                var appointments = appointmentRepository.GetAll();

                // Realizohet shfaqja e Appointments me foreach
                Console.WriteLine("Appointments:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, End Date: {appointment.AppointmentEndDate}, Patient ID: {appointment.PatientId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeleteMedicalRecord(MedicalRecordRepository medicalRecordRepository)
        {
            try
            {//kerkohet nga perdoruesi id qe do fshije
                Console.Write("Enter medical record ID to delete: ");
                long recordId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i delete qe eshte krijuar ne file tjeter.
                medicalRecordRepository.Delete(recordId);
                Console.WriteLine("Medical record deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeleteAppointment(AppointmentRepository appointmentRepository)
        {
            try
            { //kerkohet nga perdoruesi id qe do fshije
                Console.Write("Enter appointment ID to delete: ");
                long appointmentId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i delete qe eshte krijuar ne file tjeter.
                appointmentRepository.Delete(appointmentId);
                Console.WriteLine("Appointment deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddMedicalRecord(MedicalRecordRepository medicalRecordRepository)
        {
            try
            {//shtimi sipas rradhes i te dhenave te reja ne databazes per nje medical record te ri
                Console.Write("Enter patient ID: ");
                long patientId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter diagnosis (1 for positive, 0 for negative): ");
                int diagnosis = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter treatment description: ");
                string treatmentDescription = Console.ReadLine();

                Console.Write("Enter medication ID : ");
                long medicationId = Convert.ToInt32(Console.ReadLine());

                //perdorimi i add qe eshte krijuar ne file tjeter
                medicalRecordRepository.Add(new MedicalRecord { PatientId = patientId, MedicationId = medicationId, Diagnosis = diagnosis, TreatmentDescription = treatmentDescription });

                Console.WriteLine("Medical record added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdateMedicalRecord(MedicalRecordRepository medicalRecordRepository)
        {
            try
            {//kerkohet perdoruesit te vendose id qe do ndryshoje
                Console.Write("Enter medical record ID to update: ");
                long recordId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i getbyid qe eshte krijuar ne file tjt
                var record = medicalRecordRepository.GetById(recordId);

                if (record != null)
                {//vendosja e te dhenave te reja
                    Console.Write("Enter new diagnosis : ");
                    int diagnosis = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter new treatment description: ");
                    string treatmentDescription = Console.ReadLine();


                    Console.Write("Enter new medication ID : ");
                    long medicationId = Convert.ToInt32(Console.ReadLine());


                    // Updatimi i te dhenave te reja
                    record.Diagnosis = diagnosis;
                    record.TreatmentDescription = treatmentDescription;
                    record.MedicationId = medicationId;

                    // Perdorimi i update qe eshte krijuaj ne file tjeter
                    medicalRecordRepository.Update(record);
                    Console.WriteLine("Medical record updated successfully.");
                }
                else
                {
                    Console.WriteLine("Medical record not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void AddAppointment(AppointmentRepository appointmentRepository)
        {
            try
            {//kerkohet perdoruesit te vendosw te dhenat e nje appointment te ri
                Console.Write("Enter appointment date and time (yyyy-mm-dd HH:mm:ss): ");
                DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter appointment end date and time (yyyy-mm-dd HH:mm:ss): ");
                DateTime appointmentEndDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter patient ID: ");
                long patientId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter user ID: ");
                long userId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter problem description: ");
                string problemDescription = Console.ReadLine();
                bool approved = false;

                // Perdorimi i Add qe eshte krijuar ne file tjeter
                appointmentRepository.Add(new Appointment { AppointmentDate = appointmentDate, AppointmentEndDate = appointmentEndDate, PatientId = patientId, UserId = userId, ProblemDescription = problemDescription, Approved = approved });

                Console.WriteLine("Appointment added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdateAppointment(AppointmentRepository appointmentRepository)
        {
            try
            {//kerkohet perdoruesit te vendose id qe do te ndryshoje
                Console.Write("Enter appointment ID to update: ");
                long appointmentId = Convert.ToInt32(Console.ReadLine());
                //perdorimi i getbyid qe eshte krijuar ne file tjeter
                var appointment = appointmentRepository.GetById(appointmentId);
                //kontrollohet a ekziston si appointment
                if (appointment != null)
                {//vendosja e te dhenave te reja ne kete appointment ekzistues
                    Console.Write("Enter new appointment date and time (yyyy-mm-dd HH:mm:ss): ");
                    appointment.AppointmentDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter new appointment end date and time (yyyy-mm-dd HH:mm:ss): ");
                    appointment.AppointmentEndDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter new patient ID: ");
                    appointment.PatientId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new user ID: ");
                    appointment.UserId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new problem description: ");
                    appointment.ProblemDescription = Console.ReadLine();
                    //perdorimi i update qe eshte krijuar ne file tjeter
                    appointmentRepository.Update(appointment);
                    Console.WriteLine("Appointment updated successfully.");
                }
                else
                {
                    Console.WriteLine("Appointment not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        // Methodat per store procedurat
        static void GetPatientsByUser(BAL.BAL bal)
        {
            try
            {
                // Kerkon perdoruesit te vendose username
                Console.Write("Enter username to get patients: ");
                string username = Console.ReadLine();

                // kthen id e username te vendosur me lart me metoden e zhvilluar ne Bal file
                long userId = bal.GetUserIdByUsername(username);

                if (userId == 0)
                {
                    Console.WriteLine($"Username '{username}' not found.");
                    return;
                }

                // kthen te gjithe patients qe i perkasin kesaj id
                var patients = bal.GetPatientsByUser(userId);

                if (patients != null && patients.Count > 0)
                {
                    Console.WriteLine($"Patients for User '{username}' (User ID: {userId}):");
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"Patient ID: {patient.PatientId}, Name: {patient.PatientName}, Age: {patient.Age}, Weight: {patient.Weight}, Species: {patient.Species}");
                    }
                }
                else
                {//ne rast se nuk ka patient ky userid
                    Console.WriteLine($"No patients found for User '{username}' (User ID: {userId}).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void GetAppointmentsByPatient(BAL.BAL bal)
        {
            try
            {
                // Kerkon perdoruesit te vendose username
                Console.Write("Enter Patient name to get appointments: ");
                string username = Console.ReadLine();

                // kthen id e username te vendosur me lart me metoden e zhvilluar ne Bal file
                long patientId = bal.GetPatientIdByUsername(username);

                if (patientId == 0)
                {
                    Console.WriteLine($"No patient found under this name '{username}'.");
                    return;
                }

                // kthen te gjithe appointments qe i perkasin kesaj id
                var appointments = bal.GetAppointmentsByPatient(patientId);

                if (appointments != null && appointments.Count > 0)
                {
                    Console.WriteLine($"Appointments for Patient ID {patientId} ({username}):");
                    foreach (var appointment in appointments)
                    {
                        Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, End Date: {appointment.AppointmentEndDate}, User ID: {appointment.UserId}, Problem: {appointment.ProblemDescription}, Approved: {appointment.Approved}");
                    }
                }
                else
                {
                    Console.WriteLine($"No appointments found for Patient ID {patientId} ({username}).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void GetMedicalRecordsByPatient(BAL.BAL bal)
        {
            try
            {
                // Kerkon perdoruesit te vendose username
                Console.Write("Enter Patient name to get medical records: ");
                string username = Console.ReadLine();

                // kthen id e username te vendosur me lart me metoden e zhvilluar ne Bal file
                long patientId = bal.GetPatientIdByUsername(username);

                if (patientId == 0)
                {
                    Console.WriteLine($"No patient found under this name '{username}'.");
                    return;
                }
                // kthen te gjithe medical records qe i perkasin kesaj id
                var medicalRecords = bal.GetMedicalRecordsByPatient(patientId);

                if (medicalRecords != null && medicalRecords.Count > 0)
                {
                    Console.WriteLine($"Medical Records for Patient ID {patientId} ({username}):");
                    foreach (var record in medicalRecords)
                    {
                        Console.WriteLine($"Record ID: {record.RecordId}, Patient ID: {record.PatientId}, Medication ID: {record.MedicationId}, Diagnosis: {record.Diagnosis}, Treatment: {record.TreatmentDescription}");
                    }
                }
                else
                {
                    Console.WriteLine($"No medical records found for Patient ID {patientId} ({username}).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}



