﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NTaoBasic.Master" AutoEventWireup="true" CodeBehind="Nagreement.aspx.cs" Inherits="Maticsoft.Web.Nagreement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

.clause {height:380px;overflow-y:scroll;border:1px solid #7F9DB9; padding:8px 15px; }
#declare .clause p{ text-indent:2em; line-height:150%;}
.declare{padding:0 20px 0 0;text-align:right;color:#666;font-size:12px;}
.clause .unline{ text-decoration:underline; color:#000000;margin-bottom:20px;}
fieldset hr{line-height:0px;color:#ededed;background:#ededed;width:99%;margin-top:10px;}
#btn{border-top:1px solid #ededed;background:#f8f8f8;}
.legend{font-size:16px;}
#confirm,#refuse{width:200px;height:28px;margin:10px 380px 10px;letter-spacing:1px;background:#e0e0de;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
  <table id="declare"  style="height:430px;">
    <tbody><tr>
    	<td >
			<div class="clause">
			  <p style="text-align:center; font-size:14px; font-weight:bold">淘老师注册协议</p>
			  <p style="text-align:center">最后更新时间：2011年12月31日</p>
              <p>本协议由您与求知创想教育咨询（北京）有限公司共同缔结，本协议具有合同效力。</p>
			  <p>本协议中协议双方合称协议方，求知创想教育咨询（北京）有限公司在协议中亦称为"我公司"。本协议中"我公司平台"指由求知创想教育咨询（北京）有限公司运营的网络平台，包括域名为tlaoshi.com的淘老师网等。</p>
			  <p><b>一、 协议内容及签署</b></p>
			  <p> 1.本协议内容包括协议正文及所有我公司已经发布的或将来可能发布的各类规则。所有规则为本协议不可分割的组成部分，与协议正文具有同等法律效力。除另行明确声明外，任何我公司及其关联公司提供的服务（以下称为我公司平台服务）均受本协议约束。</p>
			  <p>2.您应当在使用我公司平台服务之前认真阅读全部协议内容，对于协议中以加粗字体显示的内容，您应重点阅读。如您对协议有任何疑问，应向我公司咨询。但无论您事实上是否在使用我公司平台服务之前认真阅读了本协议内容，只要您使用我公司平台服务，则本协议即对您产生约束，届时您不应以未阅读本协议的内容或者未获得我公司对您问询的解答等理由，主张本协议无效，或要求撤销本协议。</p>
			  <p>3.您承诺接受并遵守本协议的约定。如果您不同意本协议的约定，您应立即停止注册程序或停止使用我公司平台服务。</p>
              <p>4.我公司有权根据需要不时地制订、修改本协议及/或各类规则，并以网站公示的方式进行公告，不再单独通知您。变更后的协议和规则一经在网站公布后，立即自动生效。如您不同意相关变更，应当立即停止使用我公司平台服务。您继续使用我公司平台服务的，即表示您接受经修订的协议和规则。</p>
			  <p><b>二、 注册</b></p>
              <P>1.注册者资格</P>
              <p>您确认，在您完成注册程序或以其他我公司允许的方式实际使用我公司平台服务时，您应当是具备完全民事权利能力和完全民事行为能力的自然人、法人或其他组织。若您不具备前述主体资格，则您及您的监护人应承担因此而导致的一切后果，且我公司有权注销（永久冻结）您的我公司账户，并向您及您的监护人索偿。 </p>
              <p>2.账户</p>
              <p>在您签署本协议，完成会员注册程序或以其他我公司允许的方式实际使用我公司平台服务时，我公司会向您提供唯一编号的我公司账户（以下亦称账户）。 您可以对账户设置会员名和密码，通过该会员名密码或与该会员名密码关联的其它用户名密码登陆我公司平台。您设置的会员名不得侵犯或涉嫌侵犯他人合法权益。如您连续一年未使用您的会员名和密码登录我公司平台，我公司有权终止向您提供我公司平台服务，注销您的账户。账户注销后，相应的会员名将开放给任意用户注册登记使用。</p>
              <p>您应对您的账户（会员名）和密码的安全，以及对通过您的账户（会员名）和密码实施的行为负责。除非有法律规定或司法裁定，且征得我公司的同意，否则，账户（会员名）和密码不得以任何方式转让、赠与或继承（与账户相关的财产权益除外）。<b>如果发现任何人不当使用您的账户或有任何其他可能危及您的账户安全的情形时，您应当立即以有效方式通知我公司，要求我公司暂停相关服务。您理解我公司对您的请求采取行动需要合理时间，我公司对在采取行动前已经产生的后果（包括但不限于您的任何损失）不承担任何责任。</b></p>
              <p>为方便您使用我公司平台服务及我公司关联公司或其他组织的服务（以下称其他服务），您同意并授权我公司将您在注册、使用我公司平台服务过程中提供、形成的信息传递给向您提供其他服务的我公司关联公司或其他组织，或从提供其他服务的我公司关联公司或其他组织获取您在注册、使用其他服务期间提供、形成的信息。</p>
              <p>3.会员 在您按照注册页面提示填写信息、阅读并同意本协议并完成全部注册程序后或以其他我公司允许的方式实际使用我公司平台服务时，您即成为我公司平台会员（亦称会员）。</p>
              <p>在注册时，您应当按照法律法规要求，或注册页面的提示准确提供，并及时更新您的资料，以使之真实、及时，完整和准确。<b>如有合理理由怀疑您提供的资料错误、不实、过时或不完整的，我公司有权向您发出询问及/或要求改正的通知，并有权直接做出删除相应资料的处理，直至中止、终止对您提供部分或全部我公司平台服务。我公司对此不承担任何责任，您将承担因此产生的任何直接或间接支出。</b></p>
              <p>您应当准确填写并及时更新您提供的电子邮件地址、联系电话、联系地址、邮政编码等联系方式，以便我公司或其他会员与您进行有效联系，因通过这些联系方式无法与您取得联系，导致您在使用我公司平台服务过程中产生任何损失或增加费用的，应由您完全独自承担。 您在使用我公司平台服务过程中，所产生的应纳税赋，以及一切硬件、软件、服务及其它方面的费用，均由您独自承担。</p>
              
			  <p><b>三、 我公司平台服务</b></p>
              <p>1.通过我公司及其关联公司提供的我公司平台服务和其它服务，会员可在我公司平台上发布课程等交易信息、查询课程和服务信息、达成课程购买等交易意向并进行交易、对其他会员进行评价、参加我公司组织的活动以及使用其它信息服务及技术服务。</p>
              <p><b>2.您在我公司平台上交易过程中与其他会员发生交易纠纷时，一旦您或其它会员任一方或双方共同提交我公司要求调处，则我公司有权根据单方判断做出调处决定，您了解并同意接受我公司的判断和调处决定。该决定将对您具有法律约束力。</b></p>
              <p>3.您了解并同意，我公司有权应政府部门（包括司法及行政部门）的要求，向其提供您在我公司平台填写的注册信息和交易纪录等必要信息。<b>如您涉嫌侵犯他人知识产权，则我公司亦有权在初步判断涉嫌侵权行为存在的情况下，向权利人提供您必要的身份信息。</b></p>

			  <p><b>四、 我公司平台服务使用规范</b></p>
              <p>1.在我公司平台上使用我公司服务过程中，您承诺遵守以下约定：</p>
              <p><b>a) 您以个人的名义对在使用我公司平台服务过程中实施的所有行为独立承担所有的法律责任，并确保我公司免于因此产生任何损失，我公司不承担任何法律责任。您在使用我公司平台服务过程中实施的所有行为均必须遵守国家法律、法规等规范性文件及我公司平台各项规则的规定和要求，不得危害国家安全、泄漏国家机密、损害国家的荣誉和利益，不得煽动民族仇恨、民族歧视、破坏民族团结，不得破坏国家宗教政策、宣扬邪教和封建迷信，不得散步谣言、扰乱社会秩序，不得散步淫秽、色情、赌博、暴力、凶杀、恐怖或者教唆犯罪，不得违反本协议及相关规则。</b></p>
              <p>b) 在与其他会员交易过程中，遵守诚实信用原则，不采取不正当竞争行为，不扰乱网上交易的正常秩序，不从事与网上交易无关的行为。</p>
              <p>c) 不发布国家禁止销售的或限制销售的课程或服务信息（除非取得合法且足够的许可），不发布涉嫌侵犯他人知识产权或其它合法权益的课程或服务信息，不发布违背社会公共利益或公共道德或我公司认为不适合在我公司平台上销售的课程或服务信息，不发布其它涉嫌违法或违反本协议及各类规则的信息。</p>
              <p>d) 不以虚构或歪曲事实的方式不当评价其他会员，不采取不正当方式制造或提高自身的信用度，不采取不正当方式制造或提高（降低）其他会员的信用度；</p>
              <p>e) 不对我公司平台上的任何数据作商业性利用，包括但不限于在未经我公司事先书面同意的情况下，以复制、传播等任何方式使用我公司平台站上展示的资料。</p>
              <p>f) 不使用任何装置、软件或例行程序干预或试图干预我公司平台的正常运作或正在我公司平台上进行的任何交易、活动。您不得采取任何将导致不合理的庞大数据负载加诸我公司平台网络设备的行动。</p>
              <p>2.您了解并同意：</p>
              <p><b>a) 我公司有权对您是否违反上述承诺做出单方认定，并根据单方认定结果适用规则予以处理或终止向您提供服务，且无须征得您的同意或提前通知予您。</b></p>
              <p>b) 经国家行政或司法机关的生效法律文书确认您存在违法或侵权行为，或者我公司根据自身的判断，认为您的行为涉嫌违反本协议和/或规则的条款或涉嫌违反法律法规的规定的，则我公司有权在我公司平台上公示您的该等涉嫌违法或违约行为及我公司已对您采取的措施。</p>
              <p>c) 对于您在我公司平台上发布的涉嫌违法或涉嫌侵犯他人合法权利或违反本协议和/或规则的信息，我公司有权不经通知您即予以删除，且按照规则的规定进行处罚。</p>
              <p><b>d) 对于您在我公司平台上实施的行为，包括您未在我公司平台上实施但已经对我公司平台及其用户产生影响的行为，我公司有权单方认定您行为的性质及是否构成对本协议和/或规则的违反，并据此作出相应处罚。您应自行保存与您行为有关的全部证据，并应对无法提供充要证据而承担的不利后果。</b></p>
              <p>e) 对于您涉嫌违反承诺的行为对任意第三方造成损害的，您均应当以自己的名义独立承担所有的法律责任，并应确保我公司免于因此产生损失或增加费用。</p>
              <p>f) 如您涉嫌违反有关法律或者本协议之规定，使我公司遭受任何损失，或受到任何第三方的索赔，或受到任何行政管理部门的处罚，您应当赔偿我公司因此造成的损失及（或）发生的费用，包括合理的律师费用。</p>

              
			  <p><b>五、版权声明</b></p>
              <p>1.我公司一贯高度重视知识产权保护并遵守中华人民共和国各项知识产权法律、法规和具有约束力的规范性文件，坚信著作权拥有者的合法权益应该得到尊重和依法保护。我公司坚决反对任何违反中华人民共和国有关著作权的法律法规的行为。</p>
              <p>2.我公司拥有本网站内所有信息内容（包括但不限于用户上传的文字、图片、视频、课件等）的版权。任何被授权的浏览、复制、打印和传播的属于我公司站内信息内容都不得用于商业目的，我公司有权追究法律责任。</p>
              <p>3.我公司对其发行的或与合作公司共同发行的包括但不限于产品或服务的全部内容及我公司网站上的材料拥有版权等知识产权，受法律保护。</p>
              <p>4.未经本公司书面许可，任何单位及个人不得以任何方式或理由对上述产品、服务、信息、材料的任何部分进行使用、复制、修改、抄录、传播或与其它产品捆绑使用、销售。</p>
              <p>5.凡侵犯本公司版权等知识产权的，本公司必依法追究其法律责任。 </p>

			  <p><b>六、版权声明</b></p>
              <p>您完全理解并不可撤销地授予我公司及其关联公司下列权利： </p>
              <p><b>1.一旦您向我公司及（或）其关联公司，作出任何形式的承诺，且相关公司已确认您违反了该承诺，则我公司有权立即按您的承诺或协议约定的方式对您的账户采取限制措施，包括中止或终止向您提供服务，并公示相关公司确认的您的违约情况。您了解并同意，我公司无须就相关确认与您核对事实，或另行征得您的同意，且我公司无须就此限制措施或公示行为向您承担任何的责任。</b></p>
              <p><b>2.一旦您违反本协议，或与我公司签订的其他协议的约定，我公司有权以任何方式通知我公司关联公司，要求其对您的权益采取限制措施，包括但不限于将您账户内的款项支付给我公司指定的对象，要求关联公司中止、终止对您提供部分或全部服务，且在其经营或实际控制的任何网站公示您的违约情况。</b></p>
              <p><b>3.对于您提供的资料及数据信息，您授予我公司及其关联公司独家的、全球通用的、永久的、免费的许可使用权利 (并有权在多个层面对该权利进行再授权)。此外，我公司及其关联公司有权(全部或部份地) 使用、复制、修订、改写、发布、翻译、分发、执行和展示您的全部资料数据（包括但不限于注册资料、交易行为数据及全部展示于我公司平台的各类信息）或制作其派生作品，并以现在已知或日后开发的任何形式、媒体或技术，将上述信息纳入其它作品内。 </b></p>

              
			  <p><b>七、责任范围和责任限制</b></p>
              <p><b>1.我公司负责按"现状"和"可得到"的状态向您提供我公司平台服务。但我公司对我公司平台服务不作任何明示或暗示的保证，包括但不限于我公司平台服务的适用性、没有错误或疏漏、持续性、准确性、可靠性、适用于某一特定用途。同时，我公司也不对我公司平台服务所涉及的技术及信息的有效性、准确性、正确性、可靠性、质量、稳定、完整和及时性作出任何承诺和保证。</b></p>
              <p><b>2.您了解我公司平台上的信息系用户自行发布，且可能存在风险和瑕疵。我公司平台仅作为交易地点。我公司平台仅作为您获取物品或服务信息、物色交易对象、就物品和/或服务的交易进行协商及开展交易的场所，但我公司无法控制交易所涉及的物品的质量、安全或合法性，商贸信息的真实性或准确性，以及交易各方履行其在贸易协议中各项义务的能力。您应自行谨慎判断确定相关物品及/或信息的真实性、合法性和有效性，并自行承担因此产生的责任与损失。</b></p>
              <p><b>3.除非法律法规明确要求，或出现以下情况，否则，我公司没有义务对所有用户的注册数据、课程（服务）信息、交易行为以及与交易有关的其它事项进行事先审查：</b></p>
              <p><b>a) 我公司有合理的理由认为特定会员及具体交易事项可能存在重大违法或违约情形。</b></p>
              <p><b>b) 我公司有合理的理由认为用户在我公司平台的行为涉嫌违法或不当。</b></p>
              <p><b>4.我公司及其关联公司有权受理您与其他会员因交易产生的争议，并有权单方判断与该争议相关的事实及应适用的规则，进而作出处理决定。该处理决定对您有约束力。如您未在限期内执行处理决定的，则我公司及其关联公司有权利（但无义务）直接使用您账户内的款项，或您向我公司及其关联公司交纳的保证金代为支付。您应及时补足保证金并弥补我公司及其关联公司的损失，否则我公司及其关联公司有权直接抵减您在其它合同项下的权益，并有权继续追偿。</b></p>
              <p>您理解并同意，我公司及其关联公司并非司法机构，仅能以普通人的身份对证据进行鉴别，我公司及其关联公司对争议的调处完全是基于您的委托，我公司及其关联公司无法保证争议处理结果符合您的期望，也不对争议调处结论承担任何责任。如您因此遭受损失，您同意自行向受益人索偿。</p>
              <p><b>5.您了解并同意，我公司不对因下述任一情况而导致您的任何损害赔偿承担责任，包括但不限于利润、商誉、使用、数据等方面的损失或其它无形损失的损害赔偿 (无论我公司是否已被告知该等损害赔偿的可能性) ：</b></p>
              <p><b>a) 使用或未能使用我公司平台服务。</b></p>
              <p><b>b) 第三方未经批准的使用您的账户或更改您的数据。</b></p>
              <p><b>c) 通过我公司平台服务购买或获取任何课程、样品、数据、信息或进行交易等行为或替代行为产生的费用及损失。</b></p>
              <p><b>d) 您对我公司平台服务的误解。</b></p>
              <p><b>e) 任何非因我公司的原因而引起的与我公司平台服务有关的其它损失。</b></p>
              <p>6.不论在何种情况下，我公司均不对由于信息网络正常的设备维护，信息网络连接故障，电脑、通讯或其他系统的故障，电力故障，罢工，劳动争议，暴乱，起义，骚乱，生产力或生产资料不足，火灾，洪水，风暴，爆炸，战争，政府行为，司法行政机关的命令或第三方的不作为而造成的不能服务或延迟服务承担责任。</p>
              
			  <p><b>八、 协议终止</b></p>
              <p><b>1.您同意，我公司有权自行全权决定以任何理由不经事先通知的中止、终止向您提供部分或全部我公司平台服务，暂时冻结或永久冻结（注销）您的账户，且无须为此向您或任何第三方承担任何责任。</b></p>
              <p><b>2.出现以下情况时，我公司有权直接以注销账户的方式终止本协议: </b></p>
              <p><b>a) 我公司终止向您提供服务后，您涉嫌再一次直接或间接或以他人名义注册为我公司用户的； </b></p>
              <p><b>b) 您提供的电子邮箱不存在或无法接收电子邮件，且没有其他方式可以与您进行联系，或我公司以其它联系方式通知您更改电子邮件信息，而您在我公司通知后三个工作日内仍未更改为有效的电子邮箱的。</b></p>
              <p><b>c) 您注册信息中的主要内容不真实或不准确或不及时或不完整。</b></p>
              <p><b>d) 本协议（含规则）变更时，您明示并通知我公司不愿接受新的服务协议的；</b></p>
              <p><b>e) 其它我公司认为应当终止服务的情况。</b></p>
              <p><b> 3.您有权向我公司要求注销您的账户，经我公司审核同意的，我公司注销（永久冻结）您的账户，届时，您与我公司基于本协议的合同关系即终止。您的账户被注销（永久冻结）后，我公司没有义务为您保留或向您披露您账户中的任何信息，也没有义务向您或第三方转发任何您未曾阅读或发送过的信息。</b></p>
              <p>4.您同意，您与我公司的合同关系终止后，我公司仍享有下列权利 </p>
              <p>a) 继续保存您的注册信息及您使用我公司平台服务期间的所有交易信息。</p>
              <p>b) 您在使用我公司平台服务期间存在违法行为或违反本协议和/或规则的行为的，我公司仍可依据本协议向您主张权利。</p>
              <p>5.我公司中止或终止向您提供我公司平台服务后，对于您在服务中止或终止之前的交易行为依下列原则处理，您应独力处理并完全承担进行以下处理所产生的任何争议、损失或增加的任何费用，并应确保我公司免于因此产生任何损失或承担任何费用：</p>
              <p>a) 您在服务中止或终止之前已经上传至我公司平台的物品尚未交易的，我公司有权在中止或终止服务的同时删除此项物品的相关信息；</p>
              <p>b) 您在服务中止或终止之前已经与其他会员达成买卖合同，但合同尚未实际履行的，我公司有权删除该买卖合同及其交易物品的相关信息；</p>
              <p>c) 您在服务中止或终止之前已经与其他会员达成买卖合同且已部分履行的，我公司可以不删除该项交易，但我公司有权在中止或终止服务的同时将相关情形通知您的交易对方。 </p>
              
			  <p><b>九、 隐私权政策</b></p>
              <p>我公司将在我公司平台公布并不时修订隐私权政策，隐私权政策构成本协议的有效组成部分。 </p>
                   <img style=""      
			  <p><b>十、 法律适用、管辖与其他 </b></p>
              <p>1.本协议之效力、解释、变更、执行与争议解决均适用中华人民共和国法律，如无相关法律规定的，则应参照通用国际商业惯例和（或）行业惯例。</p>
              <p>2.因本协议产生之争议，应依照中华人民共和国法律予以处理，并以我公司所在地有管辖权的法院进行管辖。 </p>
    	</div></td>
    </tr>
	</tbody></table>
<div ><input id="confirm" type="button" value=" 关闭本页 " onclick="window.close()"><span></span></div>
</div>
</asp:Content>