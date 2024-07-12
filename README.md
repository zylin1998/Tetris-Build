# 俄羅斯方塊
參考：https://www.youtube.com/watch?v=jcUctrLC-7M&t=1821s
## 規則介紹
隨機生成不同形狀的方塊並放置到地圖最下方，若地圖中任一行填滿就消除，根據同時消除行數決定獲得分數，若方塊觸及頂部則失敗。
### 規則判斷
先確立基本判斷方法
```
//判斷是否能放置方塊
bool fit = TetrisModel.FitTetromino()
//檢查移動結果
bool canMove = TetrisModel.Move(int x, int y)
//放置方塊並檢查消除行數及是否遊戲結束
int clear = PlaceTetromino()
```
### 遊戲動作
```
var model = TetrisModel
//遊戲開始
model.Start()
//儲存方塊
model.Hold()
//旋轉方塊
model.RotateCW()
//逆時鐘旋轉
model.RotateCCW()
//水平移動
model.MoveHorizontal(int direction)
//向下移動
model.MoveDown()
//方塊落下
model.Drop()
```
