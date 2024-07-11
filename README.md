# 俄羅斯方塊
## 規則介紹
隨機生成不同形狀的方塊並放置到地圖最下方，若地圖中任一行填滿就消除，根據同時消除行數決定獲得分數，若方塊觸及頂部則失敗。
### 規則判斷
先確立基本判斷方法
```
//判斷是否能放置方塊
bool fit = TetrisModel.FitTetromino()
//檢查移動結果
bool canMove = TetrisModel.Move(int x, int y)
```
