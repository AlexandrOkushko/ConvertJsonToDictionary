using System;

namespace JsonToDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonV1 = @"{
                'section1' : {
                    'value1' : 'x',
                    'subsection1' : {
                        'value2' : 'y'
                    },
                    'subsection2' : {
                        'value3' : 'z'
                    }
                }
            }";

            string jsonV2 = @"
                {'widget': {
                    'debug': 'on',
                    'window': {
                        'title': 'Sample Konfabulator Widget',
                        'name': 'main_window',
                        'width': 500,
                        'height': 500
                    },
                    'image': { 
                        'src': 'Images/Sun.png',
                        'name': 'sun1',
                        'hOffset': 250,
                        'vOffset': 250,
                        'alignment': 'center'
                    },
                    'text': {
                        'data': 'Click Here',
                        'size': 36,
                        'style': 'bold',
                        'name': 'text1',
                        'hOffset': 250,
                        'vOffset': 100,
                        'alignment': 'center',
                        'onMouseUp': 'sun1.opacity = (sun1.opacity / 100) * 90;'
                    }
                }
            }";

            string jsonV3 = @"{
                'glossary': {
                    'title': 'example glossary',
		            'GlossDiv': {
                        'title': 'S',
			            'GlossList': {
                            'GlossEntry': {
                                'ID': 'SGML',
					            'SortAs': 'SGML',
					            'GlossTerm': 'Standard Generalized Markup Language',
					            'Acronym': 'SGML',
					            'Abbrev': 'ISO 8879:1986',
					            'GlossDef': {
                                    'para': 'A meta-markup language, used to create markup languages such as DocBook.',
                                },
					            'GlossSee': 'markup'
                            }
                        }
                    }
                }
            }";

            Converter3000 converter = new();
            converter.ConvertJsonToDictionary(jsonV1);
            converter.ShowConvertedData();

            converter.ConvertJsonToDictionary(jsonV2);
            converter.ShowConvertedData();

            converter.ConvertJsonToDictionary(jsonV3);
            converter.ShowConvertedData();

            Console.Write("Press any key to exit ");
            Console.ReadKey();
        }
    }
}
