﻿using Newtonsoft.Json;

public class TodoItem
{
	public string Id { get; set; }

	[JsonProperty(PropertyName = "text")]
	public string Text { get; set; }

	[JsonProperty(PropertyName = "complete")]
	public bool Complete { get; set; }
}
