using System.Collections;
using System.Collections.Generic;
using RestClient.Scripts.Core.Models;

using UnityEngine;
using UnityEngine.Networking;
 
namespace RestClient.Core
{
    public class RestWebClient : Singleton<RestWebClient>
    {
        private const string defaultContentType = "application/json";
        
        public IEnumerator HttpGet(string url, System.Action<Response> callback)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                
                if(webRequest.isNetworkError){
                    callback.Invoke(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error,
                    });
                }
                
                if(webRequest.isDone)
                {
                    string dataObj = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                    Debug.Log(webRequest.downloadHandler.text);
                    string dataText = webRequest.downloadHandler.text;
                    callback.Invoke(new Response {
                        StatusCode = webRequest.responseCode,
                        DataText = dataText,
                        Dataobj = dataObj
                    });
                    
                }
            }
        }

        public IEnumerator HttpDelete(string url, System.Action<Response> callback)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Delete(url))
            {
                yield return webRequest.SendWebRequest();

                if(webRequest.isNetworkError){
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error
                    });
                }
                
                if(webRequest.isDone)
                {
                    callback(new Response {
                        StatusCode = webRequest.responseCode
                    });
                }
            }
        }

        public IEnumerator HttpPost(string url, string body, System.Action<Response> callback, IEnumerable<RequestHeader> headers = null)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Post(url, body))
            {
                if(headers != null)
                {
                    foreach (RequestHeader header in headers)
                    {
                        webRequest.SetRequestHeader(header.Key, header.Value);
                    }
                }

                webRequest.uploadHandler.contentType = defaultContentType;
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));

                yield return webRequest.SendWebRequest();

                if(webRequest.isNetworkError)
                {
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error
                    });
                }
                
                if(webRequest.isDone)
                {
                    string dataObj = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                    string dataText = webRequest.downloadHandler.text;
                    
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        DataText = dataText,
                       Dataobj=dataObj
                    });
                }
            }
        }

        public IEnumerator HttpPut(string url, string body, System.Action<Response> callback, IEnumerable<RequestHeader> headers = null)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Put(url, body))
            {
                if(headers != null)
                {
                    foreach (RequestHeader header in headers)
                    {
                        webRequest.SetRequestHeader(header.Key, header.Value);
                    }
                }

                webRequest.uploadHandler.contentType = defaultContentType;
                webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(body));

                yield return webRequest.SendWebRequest();

                if(webRequest.isNetworkError)
                {
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error,
                    });
                }
                
                if(webRequest.isDone)
                {
                    string dataObj = System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data);
                    string dataText = webRequest.downloadHandler.text;
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Dataobj = dataObj,
                        DataText = dataText
                    });
                }
            }
        }

        public IEnumerator HttpHead(string url, System.Action<Response> callback)
        {
            using(UnityWebRequest webRequest = UnityWebRequest.Head(url))
            {
                yield return webRequest.SendWebRequest();
                
                if(webRequest.isNetworkError){
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Error = webRequest.error,
                    });
                }
                
                if(webRequest.isDone)
                {
                    var responseHeaders = webRequest.GetResponseHeaders();
                    callback(new Response {
                        StatusCode = webRequest.responseCode,
                        Headers = responseHeaders
                    });
                }
            }
        }
    }
}