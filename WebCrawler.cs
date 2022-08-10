using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// kilde: https://www.urlbox.io/website-screenshots-c-sharp
namespace RandomJelly_Classes
{
    class WebCrawler
    {   
 
        string getTime(DateTime time)
        {
            return time.ToString(); 
        }

        string LogFromat(string value)
        {
            return "[" + value + "]";   
        }



        public void GrabSceenshotEmbeded()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            // Live stream : https://www.youtube.com/watch?v=5E75hcIkPjg
            //Embedded livestream : https://www.youtube.com/embed/5E75hcIkPjg
            var weburl = "https://www.youtube.com/embed/5E75hcIkPjg";
            driver.Navigate().GoToUrl(weburl);

            try
            {
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Starter");
                Thread.Sleep(4000);
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Ferdig med å vente");
                //Trykker avvis cookies
                //driver.FindElement(By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[6]/div[1]/ytd-button-renderer[1]/a/tp-yt-paper-button")).Click();
                //Klikker fulscreen
                Thread.Sleep(3000);
                Console.WriteLine("Venter på å trykke start");
                IWebElement playBtn = driver.FindElement(By.ClassName("ytp-large-play-button"));
                playBtn.Click();
                Console.WriteLine("Trykket start, venter noen sekunder...");
                Thread.Sleep(2000);
                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Tok screenshot");
                string imagePath = "./../../../selenium-screenshot.png";
                TakeScreenshot.SaveAsFile(imagePath);

            }
            catch(Exception e )
            {
                Console.WriteLine("Noe gikk galt i henting av screenshot");
                Console.WriteLine(e.Message); 
                
            }
            driver.Quit();

        }


        public void GrabScreenshot()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            IWebDriver driver = new ChromeDriver(chromeOptions);
            // Live stream : https://www.youtube.com/watch?v=5E75hcIkPjg
            var weburl = "https://www.youtube.com/watch?v=5E75hcIkPjg";
            driver.Navigate().GoToUrl(weburl);
            try
            {
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Starter");
                Thread.Sleep(4000);
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Ferdig med å vente"); 
                //Trykker avvis cookies
                driver.FindElement(By.XPath("/html/body/ytd-app/ytd-consent-bump-v2-lightbox/tp-yt-paper-dialog/div[4]/div[2]/div[6]/div[1]/ytd-button-renderer[1]/a/tp-yt-paper-button")).Click();
                //Klikker fulscreen
                Thread.Sleep(3000);
                Console.WriteLine("Trykker fulscreen"); 
                //driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-watch-flexy/div[5]/div[1]/div/div[1]/div[2]/div/div/ytd-player/div/div/div[29]/div[2]/div[2]/button[10]")).Click();
                driver.FindElement(By.ClassName("ytp-fullscreen-button")).Click();
                Console.WriteLine(driver.FindElement(By.ClassName("ytp-fullscreen-button")));

                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                Console.WriteLine(LogFromat(getTime(DateTime.Now)) + "Tok screenshot"); 
                string imagePath = "./../../../selenium-screenshot.png";
                TakeScreenshot.SaveAsFile(imagePath);
            }

            catch (Exception e)
            {
                Console.WriteLine("Noe gikk galt?"); 
                Console.WriteLine(e.Message);
            }
            driver.Quit();

        }
        //Fullscreen button
    }///html/body/ytd-app/div[1]/ytd-page-manager/ytd-watch-flexy/div[5]/div[1]/div/div[1]/div[2]/div/div/ytd-player/div/div/div[29]/div[2]/div[2]/button[10]
    // elem : <button class="ytp-fullscreen-button ytp-button" title="Fullskjerm (f)"><svg height="100%" version="1.1" viewBox="0 0 36 36" width="100%"><g class="ytp-fullscreen-button-corner-0"><use class="ytp-svg-shadow" xlink:href="#ytp-id-69"></use><path class="ytp-svg-fill" d="m 10,16 2,0 0,-4 4,0 0,-2 L 10,10 l 0,6 0,0 z" id="ytp-id-69"></path></g><g class="ytp-fullscreen-button-corner-1"><use class="ytp-svg-shadow" xlink:href="#ytp-id-70"></use><path class="ytp-svg-fill" d="m 20,10 0,2 4,0 0,4 2,0 L 26,10 l -6,0 0,0 z" id="ytp-id-70"></path></g><g class="ytp-fullscreen-button-corner-2"><use class="ytp-svg-shadow" xlink:href="#ytp-id-71"></use><path class="ytp-svg-fill" d="m 24,24 -4,0 0,2 L 26,26 l 0,-6 -2,0 0,4 0,0 z" id="ytp-id-71"></path></g><g class="ytp-fullscreen-button-corner-3"><use class="ytp-svg-shadow" xlink:href="#ytp-id-72"></use><path class="ytp-svg-fill" d="M 12,20 10,20 10,26 l 6,0 0,-2 -4,0 0,-4 0,0 z" id="ytp-id-72"></path></g></svg></button>
    /*
     * <iframe width="629" height="354" src="https://www.youtube.com/embed/5E75hcIkPjg" title="Live Jelly Cam - Monterey Bay Aquarium" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
     * <iframe width="629" height="354" src="https://www.youtube.com/embed/5E75hcIkPjg" title="Live Jelly Cam - Monterey Bay Aquarium" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
     
     
     * <button class="ytp-large-play-button ytp-button" aria-label="Spill av"><svg height="100%" version="1.1" viewBox="0 0 68 48" width="100%"><path class="ytp-large-play-button-bg" d="M66.52,7.74c-0.78-2.93-2.49-5.41-5.42-6.19C55.79,.13,34,0,34,0S12.21,.13,6.9,1.55 C3.97,2.33,2.27,4.81,1.48,7.74C0.06,13.05,0,24,0,24s0.06,10.95,1.48,16.26c0.78,2.93,2.49,5.41,5.42,6.19 C12.21,47.87,34,48,34,48s21.79-0.13,27.1-1.55c2.93-0.78,4.64-3.26,5.42-6.19C67.94,34.95,68,24,68,24S67.94,13.05,66.52,7.74z" fill="#f00"></path><path d="M 45,24 27,14 27,34" fill="#fff"></path></svg></button>
     */
}
