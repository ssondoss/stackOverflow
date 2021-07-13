using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public enum Role
    {
        USER ,
        ADMIN
    }
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Index("Email_Index", IsUnique = true)]
        public String Email { get; set; }
        public String Password { get; set; }
        public String RepeatPassword { get; set; }
        public  Role Role { get; set; }
        public String Name { get; set; }
        public virtual List<Vote> Votes { get; set; }
        public virtual List<Answer> Answers{ get; set; }
        public virtual List<Question> Questions { get; set; }
    }

    public class Question
    {
        [Key]
        public int ID { get; set; }
        public String QuestionText { get; set; }
        [ForeignKey(nameof(User))]
        public int? userId { get; set; }
        public String Title { get; set; }
        public virtual User User { get; set; }

        public DateTime DateAndTime { get; set; }
        public virtual List<Answer> Answers { get; set; } 

    }
    public class Answer
    {
        [Key]
        public int ID { get; set; }
        public String AnswerText { get; set; }
        [ForeignKey(nameof(User))]
        public int? userId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(Question))]
        public int?  Question_id { get; set; }
        public virtual Question Question { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool CheckedByAdmin { get; set; }
        public virtual List<Vote> Votes { get; set; }

    }
    public class Vote
    {
        [Key]
        public int ID { get; set; }
        public bool VoteType { get; set; }
        public DateTime VoteDate { get; set; }
        [ForeignKey(nameof (User))]
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(Answer))]
        public int? AnswerId { get; set; }
        public virtual Answer Answer { get; set; }


    }


   


}
