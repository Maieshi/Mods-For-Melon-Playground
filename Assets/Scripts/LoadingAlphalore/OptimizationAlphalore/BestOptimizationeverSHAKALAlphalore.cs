using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Cysharp.Threading.Tasks;
public class BestOptimizationeverSHAKALAlphalore : MonoBehaviour
{
    /// <summary>
    /// Загрузка текстуры из файла из контента
    /// </summary>
    /// <param name="shortPath">Короткий путь к картинке из json. Пример: "skins/1234.jpg".</param>
    /// <param name="callback">Коллбек, который принимает в себя текстуру, которую мы получим в результате выполнения этого метода.</param>
    public static async UniTask<Texture2D> LoadTextureAlphalore(string filePathAlphalore)
    {
        //Получаем обозначение расширения файла. Тут важно понимать, что в файлах с нового контента расширение ничего не значит.
        //Оно нужно только для нас, чтобы определить использовал ли исходник картинки альфа канал.
        //Все изображения использующие альфа канал имеют расширение png. Остальные - jpeg/jpg.
        filePathAlphalore = Path.Combine(Application.persistentDataPath, filePathAlphalore);
        int lastIndexOfDotAlphalore = filePathAlphalore.LastIndexOf(".Alphalore".Replace("Alphalore", ""), StringComparison.Ordinal);
        int prefixLengthAlphalore = filePathAlphalore.Length - lastIndexOfDotAlphalore;

        string postfixAlphalore = filePathAlphalore.Substring(lastIndexOfDotAlphalore, prefixLengthAlphalore);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        //Получаем путь к файлу на устройстве. Предварительно его нужно было скачать в эту директорию.
        //Если у вас путь генерируется как-то иначе - смело меняйте эту строчку.
        // string filePath = 

        //Асинхронно читаем файл
        var readingTaskAlphalore = File.ReadAllBytesAsync(filePathAlphalore);

        await TaskExAlphalore.WaitUntilAlphalore2(() => { return readingTaskAlphalore.IsCompleted; }, 5, -1);


        //Считанные данные записываем в масив байт.
        byte[] dataAlphalore = readingTaskAlphalore.Result;


        //В последние 8 байт записана информация о изначальном разрешении картинки. Считываем ее.
        byte[] widthByteAlphalore = new byte[] { dataAlphalore[dataAlphalore.Length - 8], dataAlphalore[dataAlphalore.Length - 7], dataAlphalore[dataAlphalore.Length - 6], dataAlphalore[dataAlphalore.Length - 5] };
        byte[] heighthByteAlphalore = new byte[] { dataAlphalore[dataAlphalore.Length - 4], dataAlphalore[dataAlphalore.Length - 3], dataAlphalore[dataAlphalore.Length - 2], dataAlphalore[dataAlphalore.Length - 1] };

        //Переводим считанное разрешение в человеческий вид
        int widthAlphalore = BitConverter.ToInt32(widthByteAlphalore);
        int heightAlphalore = BitConverter.ToInt32(heighthByteAlphalore);

        Texture2D tex2DmmAlphalore;

        //Исходя из разрешения файла определяем формат сжатия который применяли к текстуре. Все изображение с альфа каналом кодились в ETC2_RGBA8. Без него - ETC2_RGB.
        //Создаем текстуру подходящего формата, с разрешением считанным из файла.
        // if (postfix == ".png")
        //     tex2Dmm = new Texture2D(width, height, TextureFormat.ETC2_RGBA8, false);
        // else
        //     tex2Dmm = new Texture2D(width, height, TextureFormat.ETC2_RGB, false);
        if ((float)((dataAlphalore.Length - 8)) / (float)(widthAlphalore * heightAlphalore) >= 1)
            tex2DmmAlphalore = new Texture2D(widthAlphalore, heightAlphalore, TextureFormat.ETC2_RGBA8, false);
        else
            tex2DmmAlphalore = new Texture2D(widthAlphalore, heightAlphalore, TextureFormat.ETC2_RGB, false);
        //Смело загружаем в эту текстуру наш массив байт.
        //Поскольку байтов в массиве больше, чем нужно, чтобы заполнить текстуру,
        //лишняя информация (например данные о разрешении в последних 8 байтах) не будет использована.
        tex2DmmAlphalore.LoadRawTextureData(dataAlphalore);
        tex2DmmAlphalore.Apply(false, false);

        //Полученную сжатую текстуру можем передавать в коллбек и использовать в своих целях.
        return tex2DmmAlphalore;
    }
}