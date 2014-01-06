using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03_Student
{
    // all student enumerations are organized in the form of UUFFSS, where UU-University number, FF-Faculty number, SS-Specialty number
    public enum Universities { TU=1, SU=2, UNWE=4, UACG=5 }
    public enum Faculties { FE=101, FKSU=102, EMF=103, FA=104,
                            FMI=201, JF=202, FHF=203, 
                            Business=401, Finances=402,
                            Architecture=501, StructureEngineering=502, Geodesy=503}
    public enum Specialties { Energetics=10101, Electrical=10102, SoftwareEngineering=10201, HeatAndNuclearPower=10301, HydrailicsAndPneumatics=10302, Calorifics=10303, Automatics=10401,
                              Mathematics=20101, Informatics=20102, ComputerScience=20203, Law=20201, EULaw=20202, Chemistry=20301, MedicalChemistry=20302,
                              IndustrialBusiness=40101, Enterpreneurship=40102, Finance=40201, Accountancy=40202,
                              Architecture = 50101, UrbanPlanning = 50102, StructureEngineering = 50201, Geodesy = 50301 }

    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ulong SSN { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public Universities University { get; set; }
        private Faculties faculty;

        public Faculties Faculty
        {
            get { return this.faculty; }
            set
            {
                // as you can see above the most 1/2 digits must correspond (and equals) to the University number
                if ((int)this.University == 0) this.University = (Universities)((int)value/100); // copies the University portion if not set 
                else if ((int)value / 100 != (int)this.University) throw new ArgumentOutOfRangeException("No such Faculty in this University");
                this.faculty = value;
            }
        }

        private Specialties specialty;
        public Specialties Specialty
        {
            get { return this.specialty; }
            // as you can see above the most 3/4 digits must correspond to the Faculty number
            set
            {
                if ((int)this.University == 0 || (int)this.Faculty == 0)
                {
                    this.University = (Universities)((int)value / 10000); // copies the University portion if not set
                    this.faculty = (Faculties)((int)value / 100); // copies the Faculty portion if not set
                }
                else if ((int)value / 100 != (int)this.faculty) throw new ArgumentOutOfRangeException("No such Specialty in this Faculty");
                this.specialty = value;
            }
        }

        public Student(string names, ulong ssn) // student names, divided by space and student SSN are required parameters for the constructor
        {
            string[] nms = names.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // splits names
            switch (nms.Length) // assigns names
            {
                case 1:
                    this.FirstName = "";
                    this.MiddleName = "";
                    this.LastName = nms[0];
                    break;
                case 2:
                    this.FirstName = nms[0];
                    this.MiddleName = "";
                    this.LastName = nms[1];
                    break;
                case 3:
                    this.FirstName = nms[0];
                    this.MiddleName = nms[1];
                    this.LastName = nms[2];
                    break;
                default: throw new ArgumentOutOfRangeException("Student names must be 1, 2 or 3, separated by space(s)");
            }

            this.SSN = ssn; // assigns SSN
        }

        // for the following three methods - Equals, == and !=, the comparison covers only student names and SSN  
        public override bool Equals(object obj)
        {
            // if object is Student, compares its names and SSN
            Student stnd = obj as Student;
            if ((object)stnd == null) return false;  // avoids recursion
            if (!this.FirstName.Equals(stnd.FirstName)) return false;
            if (!this.LastName.Equals(stnd.LastName)) return false;
            if (!this.MiddleName.Equals(stnd.MiddleName)) return false;
            if (!this.SSN.Equals(stnd.SSN)) return false;
            return true;
        }

        public static bool operator ==(Student st1, Student st2)
        {
            if ((object)st1 == null || (object)st2 == null) return false; // avoids recursion
            return st1.Equals(st2);
        }

        public static bool operator !=(Student st1, Student st2)
        {
            if ((object)st1 == null || (object)st2 == null) return true; // avoids recursion
            return !st1.Equals(st2);
        }

        public override int GetHashCode()
        {
            // Calculates hashcode as combination of names and SSN hashcoded
            string names = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            return names.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Student {{ Names: {0} {1} {2}, SSN: {3},\r\n          Address: {4},\r\n          Phone: {5}, E-mail: {6},\r\n          University: {7}, Faculty: {8}, Specialty: {9} }}",
                    this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.Phone, this.EMail, this.University, this.Faculty, this.Specialty);
        }

        public object Clone()
        {
            // copies all properties to a new object. i.e. makes deep copy
            Student newStnd = new Student(this.FirstName + " " + this.MiddleName + " " + this.LastName, this.SSN);

            newStnd.Address = this.Address;
            newStnd.Phone = this.Phone;
            newStnd.EMail = this.EMail;
            newStnd.University = this.University;
            newStnd.Faculty = this.Faculty;
            newStnd.Specialty = this.Specialty;

            return newStnd;
        }

        public int CompareTo(Student other)
        {
            int result;
            // compares names in lexicographic order 
            if (0 != (result = this.FirstName.CompareTo(other.FirstName))) return result;
            if (0 != (result = this.MiddleName.CompareTo(other.MiddleName))) return result;
            if (0 != (result = this.LastName.CompareTo(other.LastName))) return result;

            // if all equal, finally compares SSN's
            return (this.SSN.CompareTo(other.SSN));
        }
    }
}
