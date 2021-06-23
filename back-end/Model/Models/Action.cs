using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {
  public class Action : DbModel {
    [Required(ErrorMessage = "Action type is required")]
    public ActionType Type { get; set; }

    [MaxLength(50)]
    public string Location { get; set; }
    
    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }

    public virtual User User { get; set; }
    public virtual List<ActionMember> Members { get; set; }
    public virtual List<ActionEquipment> Equipment { get; set; }
  }
}