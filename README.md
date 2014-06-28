WestWorldCSharp
===============

Very sorry. We will translate this README to English later.

What's This
-----------

ここにあるのは「実例で学ぶゲーム AI プログラミング」(http://www.oreilly.co.jp/books/9784873113395/)
の第 2 章で紹介されている C++ コードを個人的に学習するために読者である私が C# で書いたものである。

第 2 章は CUI ベースの RPG みたいなものを設計、実装するという内容である。
ここでの GoF デザインパターンの STATE パターン等の応用が優れていると感じたので、コードを手で書いて覚えてみようという気になった。

オリジナルのコードは C++ で書いてあり、現物が原書サイト (http://www.jblearning.com/catalog/9781556220784/) からダウンロード可能である。
プログラムの動作を見たいのならば、そちらを当たるのが当然望ましい。

Installation
------------

Visual Studio 2013 があればビルドすることは可能だが、このプログラムはクラス設計を学習するために書いたコードであり、システムへのインストールは考慮していない。

License
-------

オリジナルコードのライセンスは原著者が有しているので、そちらを参照すること。
先に記した URL からダウンロードすることができる（読者でなくても）。

Memo
----

コードを全部書いた後の反省点および検討内容をここに記す。v1.2 のコード準拠。順不同。

* メイン関数で Bob と Elsa を for ループ内で個別に Update しているのが何かダサい。EntityManager.Update のようにするのがよさそうだ。
* そもそも class EntityManager があまり仕事をしていない。
  EntityType と BaseGameEntity インスタンスの辞書以上でも以下でもない。
* SINGLETON タイプのクラス全般。C# で実装する場合、もっとこなれた書き方はないだろうか。
  ちなみに今回は thread safety は考慮しなくてよい。
* IState のサブクラスは SINGLETON でなくてもよかった。生成コストをケチるようなクラスではない。
* class Telegram の実装は明らかに反省点が多い。C# でのオペレーターオーバーロードやハッシュ値の計算法の実装を理解していない。
* class MessageDispatcher で HashSet<Telegram> を std::set<Telegram> になぞらえて利用してしまったが、
  これは私の Telegram の比較系メソッドの実装が悪いため、まともに動作していない可能性が高い。
* まだまだありそう。
