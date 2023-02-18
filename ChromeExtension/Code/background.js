// Wait for the DOM to finish loading
chrome.webNavigation.onDOMContentLoaded.addListener(function(details) {
    // Get the current tab ID from the details object
    var tabId = details.tabId;
    
    // Execute your code here, using the tabId to interact with the current tab
    console.log("DOM content loaded in tab " + tabId);
    
    // You can also inject a content script into the tab using chrome.tabs.executeScript
    // For example, to inject a content script named "content.js":
    // chrome.tabs.executeScript(tabId, {file: "content.js"});

    // Changed to:
    chrome.scripting.executeScript({
        target: {tabId: tabId, allFrames: true},
        files: ['content.js'],
    });
  }, {url: [{schemes: ['http', 'https']}]});
