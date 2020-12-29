import React, { useRef } from 'react';
import { Text, View, Image, Dimensions, TouchableOpacity, Alert } from 'react-native';
import styles from './assets/styles/styles';
import { Feather } from '@expo/vector-icons';
import Swiper from 'react-native-deck-swiper';

import Spinner from 'react-native-loading-spinner-overlay';

import { Api } from '../../services/api';
console.disableYellowBox = true;
export default function ExploreProjects({ navigation }) {

  const [projetosAtividades, setProjetosAtividades] = React.useState([]);

  const [cardProjetoAtividadeId, setCardProjetoAtividadeId] = React.useState(null);

  const [spinner, setSpinner] = React.useState(false);

  const [TimeOut, setTimeOut] = React.useState(false);


  
  function getAtividades() {
    
    setTimeOut(false)
    new Api("ProjetoAtividade/GetAtividadesProjeto").get({ attributeBehavior: "CarregarAtividadesMatch" }).then(data => {
      var dataList = data.dataList
      setProjetosAtividades(dataList)
      setTimeout(() => {
        setTimeOut(true);
      }, 500);
    })
  }

  function Match(ProjetoAtividadeId) {
    setSpinner(true);
    new Api("Match")
      .post({ ProjetoAtividadeId: ProjetoAtividadeId, AttributeBehavior: "SalvarMatch" })
      .then(data => {
        setSpinner(false);
        Alert.alert('Solicitação enviada!', 'Por favor, aguarde o retorno da Instituição sobre a sua solicitação de participação.')
        getAtividades()
      })
      .catch(err => {
        setSpinner(false);
      });
  }



  React.useEffect(() => {

    getAtividades();

  }, []);

  const deck = useRef();

  return (

    <View style={styles.bg}>

      <Spinner
        visible={spinner}
        textContent={'Realizando Inscrição...'}
        textStyle={styles.spinnerTextStyle}
      />
      { projetosAtividades.length > 0 && TimeOut ==true ?
          <Swiper
            ref={deck}
            stackSize={1}
            infinite
            useViewOverflow={Platform.OS === 'ios'}
            backgroundColor={'transparent'}
            stackScale={5}
            stackSeparation={35}
            cardVerticalMargin={50}
            cards={projetosAtividades}
            disableTopSwipe
            disableBottomSwipe
            onSwipedRight={() => {
              Match(cardProjetoAtividadeId)
            }}
            renderCard={(card) => {
              console.log('card', card.projetoAtividadeId)
              { setCardProjetoAtividadeId(card.projetoAtividadeId) }
              return (
                < View style={styles.containerCardItem} >

                  <TouchableOpacity onPress={() => { navigation.navigate("SearchProjects") }} style={styles.loadButton}>
                    <Feather name="search" size={20} color="#FFF" />
                  </TouchableOpacity>

                  {
                    card != null && card.imagem != null ?
                      <Image source={{ uri: card.imagem }} style={styles.imageStyle} /> :

                      <Image style={styles.imageStyleAbacai} source={require('../../assets/AbacaiHome.png')}>
                      </Image>
                  }

                  <Text style={styles.nameStyle}>{card.nomeProjeto}</Text>

                  <Text style={styles.descriptionCardItem}>{card.descricaoProjeto}</Text>

                  <Text style={styles.nameStyle}>{card.nomeAtividade}</Text>

                  <Text style={styles.descriptionCardItem}>{card.descricaoAtividade}</Text>

                  <Text style={styles.nameStyle}>Habilidades Necessárias</Text>

                  <Text style={styles.descriptionCardItem}>{card.habilidade}</Text>

                  <View style={styles.actionsCardItem}>
                    <TouchableOpacity
                      style={styles.button}
                      onPress={() => deck.current.swipeLeft()}
                    >
                      <Text style={styles.dislike}>
                        {<Feather name="thumbs-down" size={35} />}
                      </Text>
                    </TouchableOpacity>

                    <TouchableOpacity style={styles.button} onPress={() => deck.current.swipeRight(Match())}>
                      <Text style={styles.like}>
                        {<Feather name="heart" size={40} />}
                      </Text>
                    </TouchableOpacity>
                  </View>

                </View>
              )
            }}
          />
          : <View style={styles.bgSemProjeto}>
            <View style={styles.viewSemProjetos} >
              <Text style={styles.nameStyle}>Opss, No momento não temos projetos próximos à sua localização.</Text>
              <Text style={styles.nameStyle}>Realize uma pesquisa e encontre novos projetos para você fazer a diferença!</Text>
              <TouchableOpacity onPress={() => { navigation.navigate("SearchProjects") }} style={{ marginTop: 20 }}>
                <Feather name="search" size={40} color="#2AB940" />
              </TouchableOpacity>
            </View>
          </View>}
    </View>
  );
};
