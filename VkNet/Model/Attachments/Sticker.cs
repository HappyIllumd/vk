﻿using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Стикер.
	/// </summary>
	[Serializable]
	public class Sticker : MediaAttachment
    {
		/// <summary>
		/// Стикер.
		/// </summary>
		static Sticker()
        {
            RegisterType(typeof(Sticker), "sticker");
        }

		/// <summary>
		/// Идентификатор набора.
		/// </summary>
		public long? ProductId { get; set; }

	    public IEnumerable<Image> Images { get; set; }

	    public IEnumerable<Image> ImagesWithBackground { get; set; }
	    

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Sticker FromJson(VkResponse response)
		{
			var sticker = new Sticker
			{
				Id = response["id"] ?? response["sticker_id"],
				ProductId = response["product_id"],
				Images = response["images"].ToReadOnlyCollectionOf<Image>(x => x),
				ImagesWithBackground  = response["images_with_background"].ToReadOnlyCollectionOf<Image>(x => x)
			};

			return sticker;
		}
	}
}