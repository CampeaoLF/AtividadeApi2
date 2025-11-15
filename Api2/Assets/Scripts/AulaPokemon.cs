
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AulaPokemon : MonoBehaviour
{
    private readonly HttpClient httpClient = new HttpClient();
    private const string baseUrl = "https://pokeapi.co/api/v2/pokemon/";
    public Image dittoImg;
    public TextMeshProUGUI dittoText;


    async void Start()
    {

        Pokemon ditto = await GetDadosPokemon("ditto");

        if (ditto != null)
        {
            Debug.Log($"Nome: {ditto.name}");
            Debug.Log($"ID: {ditto.id}");
            Debug.Log($"Altura: {ditto.height}");
            Debug.Log($"Peso: {ditto.weight}");
            Debug.Log($"Experiência Base: {ditto.base_experience}");

            if (ditto.types != null && ditto.types.Length > 0)
            {
                Debug.Log($"Tipo Principal: {ditto.types[0].type.name}");
            }

            StartCoroutine(LoadPokemonSprite(ditto.sprites.front_default));

            // Pokémon: {ditto.name} ; Tipo: {ditto.types[0].type.name}
            dittoText.text = "Pokémon: " + ditto.name + " ; Tipo: " + ditto.types[0].type.name;
        }
    }

    public async Task<Pokemon> GetDadosPokemon(string nome)
    {

        string url = baseUrl + nome.ToLower();

        HttpResponseMessage response = await httpClient.GetAsync(url);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        Pokemon pokemon = JsonUtility.FromJson<Pokemon>(jsonResponse);
        return pokemon;
    }
    IEnumerator LoadPokemonSprite(string spriteUrl)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(spriteUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                dittoImg.sprite = sprite;
                Debug.Log("Imagem de ditto carregada com sucesso!");
            }
            else
            {
                Debug.LogError($"Erro ao carregar imagem: {request.error}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        httpClient?.Dispose();
    }
}
