using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using isRock.LineBot.Conversation;

namespace LineWebHook.Models {
    public class LeaveRequest : ConversationEntity {
        [Question("請問您要請的假別是？")]
        [Order(1)]
        public string LeaveName { get; set;  }

        [Question("請問您的代理人是誰？")]
        [Order(2)]
        public string Agent { get; set; }

        [Question("請問您的請假日期是？")]
        [Order(3)]
        public DateTime LeaveDate { get; set; }

        [Question("請問您開始時間是幾點幾分？")]
        [Order(4)]
        public DateTime StartLeaveDate { get; set; }

        [Question("請問您要請幾個小時？")]
        [Order(5)]
        public float LeaveHours { get; set; }
    }
}