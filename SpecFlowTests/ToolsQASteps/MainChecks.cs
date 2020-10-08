﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KinopoiskSelenium;
using KinopoiskSelenium.Pages.ToolsQA;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowTests.ToolsQASteps
{
    [Binding]
    public sealed class MainChecks
    {
        private readonly ConciseApi _conciseApi;
        private MainChecksPage _mainPage;

        public MainChecks(ConciseApi conciseApi)
        {
            _conciseApi = conciseApi;
        }

        [Given(@"I have opened ToolsQA page")]
        public void GivenIHaveOpenedToolsQAPage()
        {
            _mainPage = new MainChecksPage(_conciseApi);
        }

        [Then(@"I check title of webpage is (.*)")]
        public void ThenICheckTitleOfWebpageIs(string title)
        {
            title = StringHelper.RemoveQuotest(title);
            Console.WriteLine($"Title from feature - {title}");
            Assert.IsTrue(_mainPage.IsCorrectTitle(title));
        }

        [Then(@"I check url is (.*)")]
        public void ThenICheckUrlIs(string url)
        {
            url = StringHelper.RemoveQuotest(url);
            Console.WriteLine($"Url from feature - {url}");
            Assert.IsTrue(_mainPage.IsCorrectUrl(url));
        }

        [Then(@"I check code source is started with (.*)")]
        public void ThenICheckCodeSourceIsStartedWith(string sourceCode)
        {
            sourceCode = StringHelper.RemoveQuotest(sourceCode);
            Console.WriteLine($"Source Code from feature - {sourceCode}");
            Assert.IsTrue(_mainPage.IsCorrectPageSource(sourceCode));
        }

    }
}