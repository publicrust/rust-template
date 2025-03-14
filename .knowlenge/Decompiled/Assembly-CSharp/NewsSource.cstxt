using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Facepunch;
using Facepunch.Extend;
using Facepunch.Flexbox;
using Facepunch.Math;
using Facepunch.Models;
using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class NewsSource : MonoBehaviour
{
	private struct ParagraphBuilder
	{
		public StringBuilder StringBuilder;

		public List<string> Links;

		public static ParagraphBuilder New()
		{
			ParagraphBuilder result = default(ParagraphBuilder);
			result.StringBuilder = new StringBuilder();
			result.Links = new List<string>();
			return result;
		}

		public void AppendLine()
		{
			StringBuilder.AppendLine();
		}

		public void Append(string text)
		{
			StringBuilder.Append(text);
		}
	}

	private static readonly Regex BbcodeParse = new Regex("([^\\[]*)(?:\\[(\\w+)(?:=([^\\]]+))?\\](.*?)\\[\\/\\2\\])?", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

	public RustText title;

	public RustText date;

	public RustText authorName;

	public HttpImage coverImage;

	public RectTransform container;

	public Button button;

	public FlexElement layoutRoot;

	public RustText paragraphTemplate;

	public HttpImage imageTemplate;

	public HttpImage youtubeTemplate;

	private static readonly string[] BulletSeparators = new string[1] { "[*]" };

	public void Awake()
	{
		GA.DesignEvent("news:view");
	}

	public void OnEnable()
	{
		if (SteamNewsSource.Stories != null && SteamNewsSource.Stories.Length != 0)
		{
			SetStory(SteamNewsSource.Stories[0]);
		}
	}

	public void SetStory(SteamNewsSource.Story story)
	{
		PlayerPrefs.SetInt("lastNewsDate", story.date);
		container.DestroyAllChildren();
		title.text = story.name;
		authorName.text = "by " + story.author;
		string text = NumberExtensions.FormatSecondsLong(Epoch.Current - story.date);
		date.text = "Posted " + text + " ago";
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(delegate
		{
			string text2 = GetBlogPost()?.Url ?? story.url;
			Debug.Log("Opening URL: " + text2);
			UnityEngine.Application.OpenURL(text2);
		});
		string firstImage = GetBlogPost()?.HeaderImage;
		ParagraphBuilder currentParagraph = ParagraphBuilder.New();
		ParseBbcode(ref currentParagraph, story.text, ref firstImage);
		AppendParagraph(ref currentParagraph);
		if (firstImage != null)
		{
			coverImage.Load(firstImage);
		}
		Facepunch.Models.Manifest.NewsInfo.BlogInfo GetBlogPost()
		{
			return ((IReadOnlyCollection<Facepunch.Models.Manifest.NewsInfo.BlogInfo>)(object)Facepunch.Application.Manifest?.News?.Blogs)?.FindWith((Facepunch.Models.Manifest.NewsInfo.BlogInfo b) => b.Title, story.name, StringComparer.InvariantCultureIgnoreCase);
		}
	}

	private void ParseBbcode(ref ParagraphBuilder currentParagraph, string bbcode, ref string firstImage, int depth = 0)
	{
		foreach (Match item in BbcodeParse.Matches(bbcode))
		{
			string value = item.Groups[1].Value;
			string value2 = item.Groups[2].Value;
			string value3 = item.Groups[3].Value;
			string value4 = item.Groups[4].Value;
			currentParagraph.Append(value);
			switch (value2.ToLowerInvariant())
			{
			case "previewyoutube":
				if (depth == 0)
				{
					string[] array2 = value3.Split(';');
					AppendYouTube(ref currentParagraph, array2[0]);
				}
				break;
			case "h1":
			case "h2":
				currentParagraph.Append("<size=200%>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</size>");
				break;
			case "h3":
				currentParagraph.Append("<size=175%>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</size>");
				break;
			case "h4":
				currentParagraph.Append("<size=150%>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</size>");
				break;
			case "b":
				currentParagraph.Append("<b>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</b>");
				break;
			case "u":
				currentParagraph.Append("<u>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</u>");
				break;
			case "i":
				currentParagraph.Append("<i>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</i>");
				break;
			case "strike":
				currentParagraph.Append("<s>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</s>");
				break;
			case "noparse":
				currentParagraph.Append(value4);
				break;
			case "url":
			{
				if (value4.Contains("[img]", StringComparison.InvariantCultureIgnoreCase))
				{
					ParseBbcode(ref currentParagraph, value4, ref firstImage, depth);
					break;
				}
				int count = currentParagraph.Links.Count;
				currentParagraph.Links.Add(value3);
				currentParagraph.Append($"<link={count}><u>");
				ParseBbcode(ref currentParagraph, value4, ref firstImage, depth + 1);
				currentParagraph.Append("</u></link>");
				break;
			}
			case "list":
			{
				currentParagraph.AppendLine();
				string[] array = GetBulletPoints(value4);
				foreach (string text3 in array)
				{
					if (!string.IsNullOrWhiteSpace(text3))
					{
						currentParagraph.Append("\t• ");
						ParseBbcode(ref currentParagraph, text3.Trim(), ref firstImage, depth + 1);
						currentParagraph.AppendLine();
					}
				}
				break;
			}
			case "olist":
			{
				currentParagraph.AppendLine();
				string[] bulletPoints = GetBulletPoints(value4);
				int num = 1;
				string[] array = bulletPoints;
				foreach (string text2 in array)
				{
					if (!string.IsNullOrWhiteSpace(text2))
					{
						currentParagraph.Append($"\t{num++} ");
						ParseBbcode(ref currentParagraph, text2.Trim(), ref firstImage, depth + 1);
						currentParagraph.AppendLine();
					}
				}
				break;
			}
			case "img":
				if (depth == 0)
				{
					string text = value4.Trim();
					if (firstImage == null)
					{
						firstImage = text;
					}
					AppendImage(ref currentParagraph, text);
				}
				break;
			}
		}
	}

	private static string[] GetBulletPoints(string listContent)
	{
		return listContent?.Split(BulletSeparators, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
	}

	private void AppendParagraph(ref ParagraphBuilder currentParagraph)
	{
		if (currentParagraph.StringBuilder.Length > 0)
		{
			string text = currentParagraph.StringBuilder.ToString();
			RustText rustText = UnityEngine.Object.Instantiate(paragraphTemplate, container);
			rustText.SetActive(active: true);
			rustText.SetText(text);
			if (rustText.TryGetComponent<NewsParagraph>(out var component))
			{
				component.Links = currentParagraph.Links;
			}
		}
		currentParagraph = ParagraphBuilder.New();
	}

	private void AppendImage(ref ParagraphBuilder currentParagraph, string url)
	{
		AppendParagraph(ref currentParagraph);
		HttpImage httpImage = UnityEngine.Object.Instantiate(imageTemplate, container);
		httpImage.SetActive(active: true);
		httpImage.Load(url);
	}

	private void AppendYouTube(ref ParagraphBuilder currentParagraph, string videoId)
	{
		AppendParagraph(ref currentParagraph);
		HttpImage httpImage = UnityEngine.Object.Instantiate(youtubeTemplate, container);
		httpImage.SetActive(active: true);
		httpImage.Load("https://img.youtube.com/vi/" + videoId + "/maxresdefault.jpg");
		RustButton component = httpImage.GetComponent<RustButton>();
		if (component != null)
		{
			string videoUrl = "https://www.youtube.com/watch?v=" + videoId;
			component.OnReleased.AddListener(delegate
			{
				Debug.Log("Opening URL: " + videoUrl);
				UnityEngine.Application.OpenURL(videoUrl);
			});
		}
	}
}
