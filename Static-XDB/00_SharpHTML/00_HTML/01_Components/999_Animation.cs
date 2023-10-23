using System.Text;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public StringBuilder _Animation(SH_Components_Animation P_SH_Components_Animation)
        {
            StringBuilder L_Animation = new StringBuilder();

            L_Animation.AppendLine("[Animation=\"" + P_SH_Components_Animation.Name + "\"]");
            L_Animation.AppendLine("{");
            L_Animation.AppendLine("animation-name: " + P_SH_Components_Animation.AnimationType.ToString().ToLower() + ";");
            L_Animation.AppendLine("animation-duration: " + P_SH_Components_Animation.Duration.ToString() + "ms;");
            L_Animation.AppendLine("animation-iteration-count: " + _Animation_Iteration(P_SH_Components_Animation.Iteration) + ";");
            L_Animation.AppendLine("}");


            return L_Animation;
        }


        private string _Animation_Iteration(int P_Iteration)
        {
            if(P_Iteration > 0)
            {
                return P_Iteration.ToString();
            }

            return "infinite";
        }

        public class SH_Components_IconInfo
        {
            public string Id { get; set; }
            public SH_Components_IconTypes IconType { get; set; }
            public string Animation { get; set; }
        }

        public class SH_Components_Animation
        {
            public string Name { get; set; }
            public SH_Components_AnimationType AnimationType { get; set; } = SH_Components_AnimationType.None;
            public int Duration { get; set; }
            public int Iteration { get; set; }
        }

        public enum SH_Components_AnimationType
        {
            None,
            Pulse
        }

        

    }
}
