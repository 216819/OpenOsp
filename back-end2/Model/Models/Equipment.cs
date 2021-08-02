using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenOsp.Model.Models {

  public class Equipment : IHasId<int>, IOwnedBy<int> {

    [Key]
    [Column("id")]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string RegistryNumber { get; set; }

    [Required(ErrorMessage = "Action's owner id is required")]
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public virtual List<ActionEquipment> Actions { get; set; }

  }

}