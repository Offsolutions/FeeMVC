using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFeeManage.Areas.Auth.Models
{
    public class Home
    {

    }
    public class tblstudentdata
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Roll No.")]
        public int rollno { get; set; }
        [Required(ErrorMessage ="Enter Your Name")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "DOB")]
        public Nullable<System.DateTime> dob { get; set; }
        [Display(Name = "Father Name")]
        public string fathername { get; set; }
        [AllowHtml]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required(ErrorMessage ="Please Enter Your 10 Digit Mobile no")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No.")]
        public string phone { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Father Phone No.")]
        public string fatherphn { get; set; }
        [Display(Name = "Language")]
        public string language { get; set; }
        [Display(Name = "Board")]
        public string board { get; set; }
        [Display(Name = "Qualification")]
        public string qualification { get; set; }
        [Display(Name = "Prior Coaching")]
        public string coaching { get; set; }
        [Display(Name = "Institute Name")]
        public string institutename { get; set; }
        [Display(Name = "Ielts Type")]
        public string type { get; set; }
        [Display(Name = "Reffered By")]
        public string refferedby { get; set; }
        [Display(Name = "Student Image")]
        public string image { get; set; }
        [Display(Name = "User")]
        public string uid { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }
        [Display(Name = "Student Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        
        public string email { get; set; }
        [Display(Name = "Discount")]
        public int discount { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       //[DefaultValue(DateTime.Now.ToString("MM-dd-yyyy"))]
        public DateTime date { get; set; }

    }
    public enum gender
    {
        Male,
        Female
    }
    public enum board
    {
        CBSE,
        PSEB,
        ICSE,
        Other
    }
    public enum type
    {
        AC,
        GT
    }
    public class Fees_Master
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Roll No.")]
        public int RollNo { get; set; }
        [Display(Name = "Total Fees")]
        public int TotalFees { get; set; }
        [Display(Name = "Paid Fees")]
        public int PaidFees { get; set; }
        [Display(Name = "Alert Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AlertDate { get; set; }
        [Display(Name = "Date")]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "Discount")]
        public int discount { get; set; }
        public bool Status { get; set; }
    }
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Fees")]
        public string Fees { get; set; }
        //public virtual ICollection<Student_Course> Student_Course { get; set; }
    }
    //public class Student_Course
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public int RollNo { get; set; }
    //    public string CourseId { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public Nullable<System.DateTime> Admitdate { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public Nullable<System.DateTime> enddate { get; set; }
    //    public string Fees { get; set; }
    //    public string Uid { get; set; }
    //    public int RoomId { get; set; }
    //    public bool Status { get; set; }

    //}

    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Roll No.")]
        public int RollNo { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Admitdate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> enddate { get; set; }
        [Display(Name = "Course Fees")]
        public string Fees { get; set; }
        [Display(Name = "User")]
        public string Uid { get; set; }
        [Display(Name = "Room")]
        public int RoomId { get; set; }
        public bool Status { get; set; }

    }
    public class Recipt_Details
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Roll No.")]
        public int RollNo { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Display(Name = "Recipt No.")]
        public string ReciptNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "Amount")]
        public int Amount { get; set; }
        public bool Active { get; set; }
    }
    public class tblReceipt
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Start No.")]
        public string Start_no { get; set; }
        [Display(Name = "End No.")]
        public string End_no { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "Current Recipt No.")]
        public string Current_Recipt { get; set; }
        public bool Status { get; set; }
    }
    public class tblroom
    {
        [Key]
        public int RoomId { get; set; }
        [Display(Name = "Room")]
        public string room { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
    public class tblreceptionist
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string email { get; set; }
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contact { get; set; }
        [Display(Name = "User Name")]
        public string login { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "User Id")]
        public string rid { get; set; }
        [Display(Name = "Image")]
        public string image { get; set; }
        [Display(Name = "User Type")]
        public string Type { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
    }

    public class tblinquiry
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string inquiryid { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Father Name")]
        public string fname { get; set; }
        [Display(Name = "Phone No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contact { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Reffered By")]
        public string referedby { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
    }
    public class tblfeedback
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string inquiryid { get; set; }
        [Display(Name = "Feedback")]
        public string feedback { get; set; }
        [Display(Name = " ")]
        public int days { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
        [Display(Name = "Next FollowUp")]
        public DateTime nextfollow { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "User")]
        public string loginid { get; set; }
    }
    public class tblfill
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Passport No.")]
        public string passport { get; set; }
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }
        [Display(Name = "DOE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime doe { get; set; }
        [Display(Name = "First Choice")]
        public string choice1 { get; set; }
        [Display(Name = "Second Choice")]
        public string choice2 { get; set; }
        [Display(Name = "Third Choice")]
        public string choice3 { get; set; }
        [Display(Name = "Module Type")]
        public string module { get; set; }
        [Display(Name = "Venue 1")]
        public string v1 { get; set; }
        [Display(Name = "Venue 2")]
        public string v2 { get; set; }
        [Display(Name = "Venue 3")]
        public string v3 { get; set; }
        [Display(Name = "Cash Mode")]
        public string mode { get; set; }
        [Display(Name = "Institute Name")]
        public string instname { get; set; }
        [Display(Name = "Module")]
        public string status { get; set; }
        [Display(Name = "Test Id")]
        public string fid { get; set; }
        [Display(Name = "Username")]
        public string uname { get; set; }
        [Display(Name = "Password")]
        public string pass { get; set; }
    }
    public enum module
    {
        GT,
        AC,
        PTE
    }
    public enum status
    {
        Idp,
        British,
        Booked,
        Not_Booked,
        Registered,
        Walkin
    }
}