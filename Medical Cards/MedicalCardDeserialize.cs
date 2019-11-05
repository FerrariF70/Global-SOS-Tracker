using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppGST
{
    /// <summary>
    /// Deserialize data for Medical Card patient
    /// </summary>
    [DataContract]
    public class MedicalCard
    {
        [DataMember(Name = "patient_id")]
        public string ID { get; set; }
        [DataMember(Name = "patient_first_name")]
        public string Name { get; set; }
        [DataMember(Name = "patient_last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "patient_birthday")]
        public string BirthDate { get; set; }
        [DataMember(Name = "patient_home_address")]
        public  string AddressOfResidence { get; set; }
        [DataMember(Name = "patient_gender")]
        public string Gender { get; set; }
        [DataMember(Name = "patient_weight")]
        public  string Weight { get; set; }
        [DataMember(Name = "patient_height")]
        public  string Growth { get; set; }
        [DataMember(Name = "patient_personal_doctors")]
        public PatientPersonalDoctor[] Doctor { get; set; }
        [DataMember(Name = "patient_med_prescriptions")]
        public PatientMedPrescription[] ListMedPrescription { get; set; }
        [DataMember(Name = "patient_medical_notes")]
        public PatientMedicalNotes[] ListMedicalNotes { get; set; }
        [DataMember (Name = "patient_health_conditions")]
        public List<PatientHealthCondition> ListHealthCondition { get; set; }
        [DataMember(Name = "database_error")]
        public string ErrorDataBase { get; set; }
        [DataMember(Name = "error")]
        public string Error { get; set; }
    }
    [DataContract(Name = "patient_personal_doctors")]
    public class PatientPersonalDoctor 
    {
        [DataMember(Name = "condition_description")]
        public  string DoctorConclusion { get; set; }
        [DataMember(Name = "doctor_contact_number_1")]
        public string DoctorContactNumber1 { get; set; }
        [DataMember(Name = "doctor_contact_number_2")]
        public string DoctorContactNumber2 { get; set; }
        [DataMember(Name = "doctor_first_name")]
        public string DoctorName { get; set; }
        [DataMember(Name = "doctor_last_name")]
        public string DoctorLastName { get; set; }
        [DataMember(Name = "doctor_office_address")]
        public string DoctorOfficeAddress { get; set; }
        [DataMember(Name = "personal_from_date")]
        public string PersonnelFromdate { get; set; }
        [DataMember(Name = "usual_visit_address")]
        public string UsualVisitAddress { get; set; }
    }
    [DataContract(Name = "patient_med_prescriptions")]
    public class PatientMedPrescription
    {
        [DataMember(Name = "prescription_date")]
        public string PrescriptionDate { get; set; }
        [DataMember(Name = "med_name")]
        public string MedName { get; set; }
        [DataMember(Name = "med_porpuse")]
        public string MedPorpuse { get; set; }
        [DataMember(Name = "active_chemicals")]
        public string ActiveChemicals { get; set; }
        [DataMember(Name = "med_volume")]
        public string MedVolume { get; set; }
        [DataMember(Name = "use_schedule")]
        public string UseSchedule { get; set; }
    }
    [DataContract(Name = "patient_medical_notes")]
    public class PatientMedicalNotes
    {
        [DataMember(Name = "note_date")]
        public string NoteDate { get; set; }
        [DataMember(Name = "note_description")]
        public string NoteDescription { get; set; }
        [DataMember(Name = "doctor_first_name")]
        public string DoctorFirstName { get; set; }
        [DataMember(Name = "doctor_last_name")]
        public string DoctorLastName { get; set; } 
    }
    [DataContract(Name = "patient_health_conditions")]
    public class PatientHealthCondition
    {
        [DataMember(Name = "condition_from_date")]
        public string ConditionFromDate { get; set; }
        [DataMember(Name = "condition_to_date")]
        public string ConditionToDate { get; set; }
        [DataMember(Name = "doctor_first_name")]
        public string DoctorFirstName { get; set; }
        [DataMember(Name = "doctor_last_name")]
        public string DoctorLastName { get; set; }
        [DataMember(Name = "condition_description")]
        public string ConditionDescription { get; set; }
        [DataMember(Name = "high_pulse_related")]
        public string HighPulseRelated { get; set; }
    }
}
