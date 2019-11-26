using System;

namespace therapist_api.Models
{
  public class therapist
  {
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int WorkPhone { get; set; }
    public int HomePhone { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public DateTime P101 { get; set; }
    public DateTime S1 { get; set; }
    public DateTime S2 { get; set; }
    public DateTime S3 { get; set; }
    public DateTime S4 { get; set; }
    public DateTime P202 { get; set; }
    public DateTime N1 { get; set; }
    public DateTime N2 { get; set; }
    public DateTime N3 { get; set; }
    public DateTime N4 { get; set; }
    public string Bach { get; set; }
    public string Certified { get; set; }
    public string SeminarsTaken { get; set; }
    public int Website { get; set; }
  }
}