using OpenOsp.Model.Enums;

namespace OpenOsp.Model.Models {
  public class ActionMember {
    public int Id { get; set; }
    public int ActionId { get; set; }
    public int MemberId { get; set; }
    public ActionMemberRole Role { get; set; }

    public virtual Action Action { get; set; }
    public virtual Member Member { get; set; }
  }
}