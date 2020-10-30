using AutoMapper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeTask3.Assembly
{
    public class NavigationTiming
    {
        readonly IJavaScriptExecutor js;

        public NavigationTiming(IJavaScriptExecutor js)
        {
            this.js = js;
        }

        public long ExecutionMethod(string name)
        {
            return Convert.ToInt64(js.ExecuteScript($"return window.performance.timing.{name}"));
        }

        public PageMetrics GetMetrics(string pageName)
        {
            var writeObjectMetrics = new
            {
                latency = GetLatency(),
                backend_response = GetBackend_response(),
                tti = GetTimeToInteract(),
                ttl = GetTimeToLoad(),
                onload = GetOnload(),
                total_time = GetTotal_time()
            };
            return new PageMetrics { Name = pageName, Metrics = writeObjectMetrics };
        }

        public async Task WriteMetricsToJsonFileAsync(List<PageMetrics> AllMetrics)
        {
            using (FileStream fs = new FileStream("metrics.json", FileMode.Open))
            {
                await JsonSerializer.SerializeAsync(fs, AllMetrics);
            }
        }

        //raw data
        public long GetNavigationStart() => ExecutionMethod("navigationStart");
        public long GetUnloadEventStart() => ExecutionMethod("unloadEventStart");
        public long GetUnloadEventEnd() => ExecutionMethod("unloadEventEnd");
        public long GetRedirectStart() => ExecutionMethod("redirectStart");
        public long GetRedirectEnd() => ExecutionMethod("redirectEnd");
        public long GetFetchStart() => ExecutionMethod("fetchStart");
        public long GetDomainLookupStart() => ExecutionMethod("domainLookupStart");
        public long GetDomainLookupEnd() => ExecutionMethod("domainLookupEnd");
        public long GetConnectStart() => ExecutionMethod("connectStart");
        public long GetConnectEnd() => ExecutionMethod("connectEnd");
        public long GetSecureConnectionStart() => ExecutionMethod("secureConnectionStart");
        public long GetRequestStart() => ExecutionMethod("requestStart");
        public long GetResponseStart() => ExecutionMethod("responseStart");
        public long GetResponseEnd() => ExecutionMethod("responseEnd");
        public long GetDomLoading() => ExecutionMethod("domLoading");
        public long GetDomInteractive() => ExecutionMethod("domInteractive");
        public long GetDomContentLoadedEventStart() => ExecutionMethod("domContentLoadedEventStart");
        public long GetDomContentLoadedEventEnd() => ExecutionMethod("domContentLoadedEventEnd");
        public long GetDomComplete() => ExecutionMethod("domComplete");
        public long GetLoadEventStart() => ExecutionMethod("loadEventStart");
        public long GetLoadEventEnd() => ExecutionMethod("loadEventEnd");

        //results
        public long GetLatency()=> GetResponseStart() - GetNavigationStart();
        public long GetBackend_response()=>GetResponseEnd() - GetResponseStart();
        public long GetTimeToInteract() => GetDomInteractive() - GetDomLoading();
        public long GetTimeToLoad() => GetDomComplete() - GetDomInteractive();
        public long GetOnload() =>GetLoadEventEnd() - GetLoadEventStart();
        public long GetTotal_time() =>GetLoadEventEnd() - GetNavigationStart();

    }
}
