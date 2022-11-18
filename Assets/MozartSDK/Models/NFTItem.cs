﻿namespace Mozart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    /* From GO code schema
     * field.Uint64("id").DefaultFunc(entutils.GenUint64Id),
		field.Time("created").Default(time.Now),
		field.Time("modified").Default(time.Now).UpdateDefault(time.Now),

		field.String("name").Default(""),
		field.String("image").Default(""),
		field.String("description").Default(""),
		field.JSON("metadata", map[string]interface{}{}).Default(map[string]interface{}{}),

		// from-edges
		field.Uint64("userId"),
		field.Uint64("collectionId"),*/

    public class NFTItem
    {
        /*[string] The id of the Nft.*/
        public string nftId;

        /*[string] NO DESCRIPTION, PLEASE ADD TO API.YAML*/
        public string userId;

        /*[string] NO DESCRIPTION, PLEASE ADD TO API.YAML*/
        public string collectionId;

        /*[string] The name of the NFT. This will be shown on third party marketplaces such as OpenSea.
*/
        public string name;

        public string itemKey;

        public int price;

        /*[string] The image associated with the NFT. This will be shown on third party marketplaces such as OpenSea.
*/
        public string image;

        /*[string] The description of the NFT. This will be shown on third party marketplaces such as OpenSea
*/
        public string description;

        /*[string] Address of the deployed contract for the NFT.*/
        public string contractAddress;

        /*[object] This includes a variable number of key/value pairs as metadata of the NFT.
*/
        public Dictionary<String, DictionaryBase> metadata = new Dictionary<string, DictionaryBase>();
    }

}