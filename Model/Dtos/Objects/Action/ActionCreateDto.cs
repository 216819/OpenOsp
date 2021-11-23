using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OpenOsp.Model.Enums;

using OspDA = OpenOsp.Model.DataAnnotations;

namespace OpenOsp.Model.Dtos {
  public class ActionCreateDto {
    [OspDA.RequiredAttribute] public ActionType Type { get; set; }

    [OspDA.RequiredAttribute]
    [OspDA.MaxLengthAttribute(64)]
    public string Location { get; set; }

    [Display(Name = "Start time")]
    [OspDA.RequiredAttribute]
    public DateTime StartTime { get; set; }

    [Display(Name = "End time")]
    [OspDA.RequiredAttribute]
    [OspDA.DateGreaterEqualAttribute("StartTime")]
    public DateTime EndTime { get; set; }

    public virtual IEnumerable<ActionMemberCreateDto> Members { get; set; }

    public virtual IEnumerable<ActionEquipmentCreateDto> Equipment { get; set; }
  }
}