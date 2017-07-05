using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeviceCheckout.Models;

namespace DeviceCheckout.Controllers
{
    public class APIController : ApiController
    {

        // Get: API
        // Returns: "Device Checkout v1.0"
        [HttpGet]
        [Route("api")]
        public string API()
        {
            return "Device Checkout v1.0";
        }

        // Get: API/getstudentinfo
        // Returns: "Object: studentInfo Table"
        [HttpGet]
        [Route("api/getstudentinfo")]
        public object getStudentInfo()
        {
            using (var db = new DeviceCheckoutEntities())
            {
                var studentInfo = db.studentInfo.ToList();
                return studentInfo;
            }
        }

        // Get: API/getdevicepreset
        // Return: "Object: devicePreset Table"
        [HttpGet]
        [Route("api/getdevicepreset")]
        public object getDevicePresent()
        {
            using (var db = new DeviceCheckoutEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var devicePreset = db.devicePreset.ToList();
                return devicePreset;
            }
        }

        public class zoneInformation
        {
            public object deviceInfo0 { get; set; }
            public object zoneInfo { get; set; }

        }

        // Get: API/getdeviceinfourl ?input=0
        [HttpGet]
        [Route("api/getdeviceinfourl")]
        public object getDeviceInfoUrl(int input)
        {
            using (var db = new DeviceCheckoutEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                var deviceInfoUrl = db.deviceInfo.Where(x => x.devicePresetId == input).ToList();

                List<zoneInformation> zoneID = new List<zoneInformation>();

                foreach (var item in deviceInfoUrl)
                {
                    zoneID.Add(
                        new zoneInformation()
                        {
                            deviceInfo0 = deviceInfoUrl,
                            zoneInfo = db.zone.Where(x => x.Id == item.zoneId).Select(x => x.nameOfZone).ToList()
                        });
                }
                return zoneID;
            }
        }

        // Get: API/getorderinfo ?orderId=XXX&serialId=XXX&date1="11/30/2015 12:00:00 AM"&date2="11/30/2015 12:00:00 AM"
        [HttpGet]
        [Route("api/getorderinfo")]
        public object getOrderInfo(int orderId, int serialId, DateTime date1, DateTime date2)
        {

            using (var db = new DeviceCheckoutEntities())
            {
                var select = db.orderInfo.ToList();
            }

            return Ok();
        }


    }
}
