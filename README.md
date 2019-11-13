# Devils
> Devils란? 우월한 재능을 가졌지만 그외 부분은 상대적으로 부족한 경우 우리가 흔히 말하는 '악마의 재능'이란 말에서 따온 이름입니다. 자신의 재능을 이용해서 개발자의 불필요한? 고민의 시간을 줄여주고 최소한의 결정으로 최대한의 효과를 낼 수 있게 도와주는 프레임워크입니다.

1. 관습적이지 않은 부분의 코드만 작성 작동하도록 기본값을 설정합니다.
2. 로직과 데이터를 분리시킬 수 있도록 도와줍니다. 
3. 기능간의 관계성을 제거시켜 독립화가 가능합니다.
4. 모듈화를 통해 기능의 재사용이 손쉽게 가능하게 됩니다.



## new
> 새로운 프로젝트 및 각종 코드를 생성하는 명령입니다. 

#### server
* 새로운 서버를 생성합니다.
* 2019-11-11 현재 .netcore webapi 서버만 지원합니다.
* 사용
  * devils new server [name] --type [type]  --path [path]
    * [name] : 서버명
    * [type] : 서버 타입
    * [path] : 생성 경로
    * 예) devils new server TestServer --type webapi --path /home/user/work/


#### service
* 새로운 서비스를 생성합니다.
* 서비스란? 프로젝트를 구성하는 컨텐츠의 단위로 프로토콜, 로직, 게임리소스, DB처리 등을 자체적으로 처리할 수 있으며, 서버측에서 dll 참조여부로 생성과 제거가 가능합니다.
* 로그인 서비스, 영웅 서비스, 퀘스트 서비스 등의 서비스들을 조합하여 보다 손쉽게 게임서버를 생성할 수 있도록 하는것이 최종 목적입니다.
* 사용
  * devils new service [name] (--path [path])
    * [name] : 서비스명
    * [path] : 생성 경로
    * 예) devils new service TestService --path /home/user/work/  


#### action
* 새로운 액션을 생성합니다.
* 액션이란? 패킷 요청으로 처리되는 비지니스 로직으로 이와 관련된 패킷관련 데이터까지 포함된 개념으로 "요청->처리->응답"으로 구성됩니다.
* 명령 실행시 XXXAction.cs와 XXX.proto.json파일이 생성되며 XXX.proto.json에 패킷 데이터를 정의하고 restore명령을 통해 XXXProto.cs가 생성되면 실제로 로직에서 패킷 데이터를 사용할 수 있습니다.
* 사용
  * devils new action [name] (--path [path])
    * [name] : 액션명
    * [path] : 생성 경로
    * 예) devils new action login --path /home/user/work/TestService/



## restore
> json 스크립트에 작성된 정보를 코드로 복원시키는 명령입니다.


#### action
* 액션에서 사용되는 패킷 데이터를 코드로 복원시킵니다.
* 사용
  * devils restore action [name] (--path [path])
    * [name] : 액션명
    * [path] : 생성 경로
    * 예) devils restore action login --path /home/user/work/TestService/
