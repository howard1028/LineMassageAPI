using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;

using isRock.LineBot;

namespace LineWebHook.Controllers {
    public class HomeController : Controller {
        string toUserID = WebConfigurationManager.AppSettings["ToUserId"];
        Bot bot { get; set; }

        public HomeController() {
            bot = new Bot();
        }

        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult DispatchText() {
            bot.PushMessage(toUserID, "測試訊息");
            return View("Index");    
        }

        public ActionResult DispatchPicture() {
            Uri imageUrl = new Uri("https://attach2.mobile01.com/images/logo/logo.png");
            bot.PushMessage(toUserID, imageUrl);
            return View("Index");
        }

        public ActionResult DispatchSticker() {
            bot.PushMessage(toUserID, 1, 6);
            return View("Index");
        }

        public ActionResult DispatchTemplate1() {
            var actions = new List<TemplateActionBase>();

            actions.Add(new MessageAction() { label = "男裝", text = "man" });
            actions.Add(new MessageAction() { label = "女裝", text = "woman" });
            actions.Add(new MessageAction() { label = "童裝", text = "children" });

            var tmpl = new ButtonsTemplate() {
                thumbnailImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/LINE_logo.svg/200px-LINE_logo.svg.png"),
                text = "請問您想購買哪一類的服飾？",
                title = "詢問",
                altText = "快快樂樂發送了一個詢問，",
                actions = actions
            };

            bot.PushMessage(toUserID, tmpl);
            return View("Index");
        }

        public ActionResult DispatchTemplate2() {
            var actions = new List<TemplateActionBase>();

            actions.Add(new MessageAction() { label = "同意", text = "yes" });
            actions.Add(new MessageAction() { label = "拒絕", text = "no" });

            var tmpl = new ConfirmTemplate() {
                text = "請問您想選擇的是？",
                altText = "快快樂樂發送了一個詢問，",
                actions = actions
            };

            bot.PushMessage(toUserID, tmpl);

            return View("Index");
        }

        public ActionResult DispatchTemplate3() {
            var actions = new List<TemplateActionBase>();

            actions.Add(new MessageAction() { label = "標題 - 文字回復", text = "回復文字" });
            actions.Add(new UriAction() { label = "標題 - Google", uri = new Uri("http://www.google.com") });
            actions.Add(new PostbackAction() { label = "標題 - 發生Postback", data = "abc=aaa&def=111" });

            var column = new Column {
                text = "ButtonTemplate文字訊息",
                title = "ButtonTemplate標題",
                thumbnailImageUrl = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/LINE_logo.svg/200px-LINE_logo.svg.png"),
                actions = actions
            };

            var tmpl = new CarouselTemplate() {
                altText = "快快樂樂發送了一個詢問，"
            };

            tmpl.columns.Add(column);
            tmpl.columns.Add(column);
            tmpl.columns.Add(column);

            bot.PushMessage(toUserID, tmpl);

            return View("Index");
        }

        public ActionResult DispatchTemplate4() {
            var columns = new List<ImageCarouselColumn>() {
                    new ImageCarouselColumn() {
                        action = new MessageAction() { label = "標題1", text = "回復文字" },
                        imageUrl = new Uri("https://image.shutterstock.com/image-vector/prevent-coronavirus-covid19-2019ncov-virus-600w-1680510709.jpg")
                    },

                    new ImageCarouselColumn() {
                        action = new PostbackAction() { label = "標題2", data = "abc=aaa&def=111" },
                        imageUrl = new Uri("https://image.shutterstock.com/image-vector/coronavirus-pandemic-medical-infographics-horizontal-600w-1679579902.jpg")
                    },

                    new ImageCarouselColumn() {
                        action = new UriAction() { label = "標題3", uri = new Uri("http://www.google.com") },
                        imageUrl = new Uri("https://image.shutterstock.com/image-vector/symptoms-coronaviruscovid19-vector-illustrations-set-600w-1656329914.jpg")
                    }
                };

            var tmpl = new ImageCarouselTemplate() {
                columns = columns,
                altText = "快快樂樂發送了一個詢問，"
            };

            bot.PushMessage(toUserID, tmpl);

            return View("Index");
        }

        public ActionResult DispatchQuickReply() {
            TextMessage msg = new TextMessage("請問你要請什麼假別？");

            msg.quickReply.items.Add(new QuickReplyMessageAction("特休", "特休", new Uri("https://image.flaticon.com/icons/svg/883/883787.svg")));
            msg.quickReply.items.Add(new QuickReplyMessageAction("事假", "事假", new Uri("https://image.flaticon.com/icons/svg/60/60535.svg")));
            msg.quickReply.items.Add(new QuickReplyMessageAction("病假", "病假", new Uri("https://image.flaticon.com/icons/svg/68/68544.svg")));

            bot.PushMessage(toUserID, msg);

            return View("Index");
        }

        public ActionResult DispatchLIFF() {
            bot.PushMessage(toUserID, "line://app/1653987298-W3Ve171M");

            return View("Index");
        }
    }
}
