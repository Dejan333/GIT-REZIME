using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;


public class Student
{
    [Key]
    [Required]
    public int StudentID { get; set; }
    [StringLength(25, ErrorMessage = "Ime ne moze imati vise od 25 karaktera")]
    [Required(ErrorMessage = "Ime je obavezno za unos")]
    public string Ime { get; set; }
    [Required]
    [StringLength(25)]
    public string Prezime { get; set; }
    [Required]
    [StringLength(13)]
    public string JMBG { get; set; }
    [Required]
    [StringLength(15)]
    [DisplayName("Broj indeksa")]
    public string BrojIndeksa { get; set; }
    [Required]
    public int PostanskiBrojGrada { get; set; }
    public virtual ICollection<PrijavaIspita> PrijavaIspita { get; set; }
}

public class Ispit
{
    [Key]
    [Required]
    public int IspitID { get; set; }
    [Required]
    [StringLength(15)]
    public string SifraIspita { get; set; }
    [Required]
    [StringLength(15)]
    public string Naziv { get; set; }
    public virtual ICollection<PrijavaIspita> PrijavaIspita { get; set; }

}
public class Predmet
{
    [Key]
    [Required]
    public int PredmetID { get; set; }
    [Required]
    [StringLength(1)]
    public string Sifra { get; set; }
    [StringLength(15)]
    public string Naziv { get; set; }
    public virtual ICollection<PrijavaIspita> PrijavaIspita { get; set; }
}
public class PrijavaIspita
{
    [Key, Column(Order = 0)]
    public int IspitID { get; set; }
    [Key, Column(Order = 1)]
    public int StudentID { get; set; }
    [Key, Column(Order = 2)]
    public int PredmetID { get; set; }
    public string BrojPrethodnihPolaganja { get; set; }
    public virtual Student Student { get; set; }
    public virtual Ispit Ispit { get; set; }
    public virtual Predmet Predmet { get; set; }
}

public class Primer
{
    [Key]
    [Required]
    public int StudentID { get; set; }
    [StringLength(25, ErrorMessage = "Ime ne moze imati vise od 25 karaktera")]
    [Required(ErrorMessage = "Ime je obavezno za unos")]
    public string Ime { get; set; }
    [Required]
    [StringLength(25)]
    public string Prezime { get; set; }
    [Required]
    [StringLength(13)]
    public string JMBG { get; set; }
    [Required]
    [StringLength(15)]
    [DisplayName("Broj indeksa")]
    public string BrojIndeksa { get; set; }
    [Required]
    public int PostanskiBrojGrada { get; set; }
}

