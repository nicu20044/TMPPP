using TMPPP.Domain.Entities;

namespace TMPPP.Proxy
{
    public interface IMedicalAccess
    {
        string GetDetails(Athlete athlete, string userRole);
    }

    public class MedicalDepartment : IMedicalAccess
    {
        public string GetDetails(Athlete athlete, string userRole)
        {
            // Logica reala de extragere din baza de date
            return $"DOSAR CONFIDENTIAL #{athlete.Id}: {athlete.MedicalStatus}";
        }
    }

    public class SecurityProxy : IMedicalAccess
    {
        private MedicalDepartment _realDepartment;

        public string GetDetails(Athlete athlete, string userRole)
        {
            if (userRole != "Admin" && userRole != "Doctor")
            {
                return "ACCES REFUZAT: Nu aveti permisiunea de a vedea datele medicale.";
            }

            if (_realDepartment == null) _realDepartment = new MedicalDepartment();
            
            // Logare acces in DB
            return _realDepartment.GetDetails(athlete, userRole);
        }
    }
}
