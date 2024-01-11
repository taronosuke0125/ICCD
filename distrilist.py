import re

def distrilist(text):
    list = []
    i=1
    while True:
        try: 
            #i.で始まる部分の抽出
            pre = text[text.index(str(i)+"."):]
            #。で終わるよう区切る
            end = pre[:pre.index("。")]
            #上で抽出した分をリストに格納
            list.insert(i,end)
            i=i+1
            print('z')
        except:
            #例外が発生したら(全ての項目をリストに格納したら)リストを返す
            
            print(list)
            exit()


if __name__ == '__main__':
    text = "1.aaaaa。2.bbbbb。3.ccccc。4.ddddd。"
    distrilist(text)
    