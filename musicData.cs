using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp11
{
    class musicData
    {

        public stat status { get; set; }
        public dat metadata { get; set; }



        public string cost_time { get; set; }
        public string result_type { get; set; }

        public class stat
        {
            public string msg { get; set; }
            public string code { get; set; }
            public string version { get; set; }
        }
        public class dat
        {
            public mus music { get; set; }
            public class mus
            {
                public ext external_ids { get; set; }


                public class ext
                {
                    public string isrc { get; set; }
                    public string upc { get; set; }
                }
                public string play_offset_ms { get; set; }

                public extDat external_metadata { get; set; }
                public class extDat
                {
                    public story musicstory { get; set; }
                    public class story
                    {
                        public alb album { get; set; }
                        public class alb
                        {
                            public string id { get; set; }
                        }
                        public rel release { get; set; }
                        public class rel
                        {
                            public string id { get; set; }
                        }

                        public trk track { get; set; }
                        public class trk
                        {
                            public string id { get; set; }
                        }
                    }

                    public find lyricfind { get; set; }
                    public class find
                    {
                        public string lfid { get; set; }
                    }
                    public deez deezer { get; set; }
                    public class deez
                    {
                        public alb album { get; set; }
                        public class alb
                        {
                            public string id { get; set; }
                        }
                    }
                    public tube youtube { get; set; }
                    public class tube
                    {
                        public string vid { get; set; }
                    }

                    public spot spotify { get; set; }
                    public class spot
                    {
                        public alb album { get; set; }
                        public class alb
                        {
                            public string id { get; set; }
                        }
                        public art artists { get; set; }
                        public class art
                        {
                            public string id { get; set; }
                        }
                        public trk track { get; set; }
                        public class trk
                        {
                            public string id { get; set; }
                        }
                    }
                }
                public gen genres { get; set; }
                public class gen
                {
                    public string name { get; set; }
                }
                public string score { get; set; }
                public string release_date { get; set; }
                public string title { get; set; }
                public string label { get; set; }
                public string duration_ms { get; set; }
                public alb album {get;set;}
                public class alb
                {
                    public string name { get; set; }
                }
                public string acrid { get; set; }
                public string result_from { get; set; }
                public string artists { get; set; }
            }
            public string timestamp_utc { get; set; }
        }
    }
}

