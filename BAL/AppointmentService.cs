using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP.BAL
{//Ky eshte file BAL per appointment dhe do permbaje llogjiken e funksioneve qe jane thirrur ne DAL per appointment.
    public class AppointmentService
    {
        public IRepository<Appointment> appointment_Repository;

        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            appointment_Repository = appointmentRepository;
        }
        //Thirret funksioni GetAllAppointments ku do realizohet perdorimi i 
        //llogjikes se GetAll per kthimin e te gjitha te dhenat nga appointment.
        public List<Appointment> GetAllAppointments()
        {
            return appointment_Repository.GetAll();
        }
        //Thirret funksioni GetAppointmentById qe do kerkoje Id qe do kerkoje appointment ku do realizohet perdorimi i getbyid qe eshte krijuar ne DAL file. 

        public Appointment GetAppointmentById(long id)
        {//perdorimi i try catch ne rast se ka error ne kthimin e appointment me id perkatese.
            try
            {
                return appointment_Repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving appointment by id: {ex.Message}");
                return null;
            }
        }
        //Llogjika e krijimit te nje appointment te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen appointment ne sql.

        public void CreateAppointment(DateTime appointmentDate, DateTime appointmentEndDate, long patientId, long userId, string problemDescription)
        {
            Appointment newAppointment = new Appointment
            {//Krijimi i konstruktoreve per parametrat me lart.
                AppointmentDate = appointmentDate,
                AppointmentEndDate = appointmentEndDate,
                PatientId = patientId,
                UserId = userId,
                ProblemDescription = problemDescription
            };
            //Perdorimi i funksionit Add nga interface qe trashegon per te shtuar kete Appointment te ri qe krijuam.
            appointment_Repository.Add(newAppointment);
        }
        //Llogjika e updatimit te nje Appointment te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen Appointment ne sql.

        public void UpdateAppointment(long id, DateTime appointmentDate, DateTime appointmentEndDate, long patientId, long userId, string problemDescription)
        {////Perdorimi i funksionit GetById nga interface qe trashegon per te kerkuar kete appointment me id perkatese .
            ///Nese ekziston si id atehere behen ndryshime ne rreshtat e appointment.
            Appointment appointment = appointment_Repository.GetById(id);
            if (appointment != null)
            {//Krijimi i konstruktoreve per parametrat me lart.
                appointment.AppointmentDate = appointmentDate;
                appointment.AppointmentEndDate = appointmentEndDate;
                appointment.PatientId = patientId;
                appointment.UserId = userId;
                appointment.ProblemDescription = problemDescription;
                //Perdorimi i funksionit Update nga interface qe trashegon appointment.

                appointment_Repository.Update(appointment);
            }
        }
        //Llogjika e fshirjes te nje appointment ekzistues ne databaze.Funksioni ka paramenter id e appointment.

        public void DeleteAppointment(long id)
        {//Perdorimi i funksionit Delete nga interface qe trashegon appointment.
            appointment_Repository.Delete(id);
        }
        // Shembull perdorimi i LINQ query dhe dictionary qe kthen appointment me key value pair (id-appointment_ProblemDescription).

        public Dictionary<long, string> GetAppointmentDictionary()
        {//Perdorimi i funksionit getall nga interface qe trashegon appointment.
            List<Appointment> appointments = appointment_Repository.GetAll();
            return appointments.ToDictionary(appointment => appointment.AppointmentId, appointment => appointment.ProblemDescription);
        }
        // Shembull i perdorimit te foreach ku do printoje te gjithe appointment e regjistruar ne databaze.

        public void PrintAllAppointments()
        {//Perdorimi i funksionit getall nga interface qe trashegon appointment.
            List<Appointment> appointments = appointment_Repository.GetAll();
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Appointment: {appointment.AppointmentId}, Date: {appointment.AppointmentDate}, Problem: {appointment.ProblemDescription}");
            }
        }
    }

}
