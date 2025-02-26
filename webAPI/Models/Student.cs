using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Models;

[Table("students")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("class")]
    public int Class { get; set; }

    [Column("address")]
    [StringLength(255)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("password")]
    public int? Password { get; set; }

    public int Gender { get; set; }
}
