import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { Feather } from '@expo/vector-icons';


import Login from './pages/Login';
import CreateAccount from './pages/CreateAccount';
import ForgottenPassword from './pages/ForgottenPassword';
import Home from './pages/Home';
import Details from './pages/Details';
import DetailsInst from './pages/Details/detailsInst';
import Perfil from './pages/Perfil';
import PersonalInformation from './pages/PersonalInformation';
import Notificacao from './pages/Notificacao';
import NotificacaoInstituto from './pages/NotificacaoInstituto';
import detalhesNotificacao from './pages/NotificacaoInstituto/detalhesNotificacao';
import Ods from './pages/Ods'
import DetalhesOds from './pages/Ods/detalhesods.js';
import SearchProjects from './pages/ExploreProjects/searchPage';
import ExploreProjects from './pages/ExploreProjects';
import CreateProject from './pages/CreateProject';
import CreateTask from './pages/CreateTask';
import UserProject from './pages/UserProject';
import Info from './pages/Info';
import { AsyncStorage } from 'react-native';
// import Loading from '../screens/Loading';

import * as Auth from './services/auth';

const HomeStack = createStackNavigator();
const HomeStackScreen = () => (
  <HomeStack.Navigator screenOptions={{ headerShown: false }}>
    <HomeStack.Screen
      name="Home"
      component={Home}
    />
    <HomeStack.Screen
      name="Details"
      component={Details}
    />
    <HomeStack.Screen
      name="DetailsInst"
      component={DetailsInst}
    />
    <HomeStack.Screen
      name="CreateProject"
      component={CreateProject}
    />
    <HomeStack.Screen
      name="UserProject"
      component={UserProject}
    />
    <HomeStack.Screen
      name="CreateTask"
      component={CreateTask}
    />
  </HomeStack.Navigator>
);

const ProfileStack = createStackNavigator();
const ProfileStackScreen = () => (
  <ProfileStack.Navigator screenOptions={{ headerShown: false }}>
    <ProfileStack.Screen
      name="Perfil"
      component={Perfil}
    />
    <ProfileStack.Screen
      name="PersonalInformation"
      component={PersonalInformation}
    />
    <ProfileStack.Screen
      name="Notificacao"
      component={Notificacao}
    />
    <ProfileStack.Screen
      name="NotificacaoInstituto"
      component={NotificacaoInstituto}
    />
    <ProfileStack.Screen
      name="detalhesNotificacao"
      component={detalhesNotificacao}
    />
    <ProfileStack.Screen
      name="Ods"
      component={Ods}
    />
    <ProfileStack.Screen
      name="DetalhesOds"
      component={DetalhesOds}
    />
    <ProfileStack.Screen
      name="Info"
      component={Info}
    />
  </ProfileStack.Navigator>
);

const ExploreProjectsStack = createStackNavigator();
const ExploreProjectsStackScreen = () => (
  <ExploreProjectsStack.Navigator screenOptions={{ headerShown: false }}>
    <ExploreProjectsStack.Screen
      name="ExploreProjects"
      component={ExploreProjects}
    />
    <ExploreProjectsStack.Screen
      name="SearchProjects"
      component={SearchProjects}
    />
  </ExploreProjectsStack.Navigator>
);

const AppTabs = createBottomTabNavigator();
const AppTabsScreen = () => {
  const [ehInstituicao, setEhInstituicao] = React.useState();
  React.useEffect(() => {
    async function canAccess() {

      setEhInstituicao(
        await Auth.isInstituicao()
      );
    }

    canAccess();

  }, []);

  return(
  <AppTabs.Navigator screenOptions={{ headerShown: false }} tabBarOptions={{ activeTintColor: "#2AB940" }} >
    <AppTabs.Screen
      name="Inicio"
      component={HomeStackScreen}
      options={{
        tabBarIcon: props => (
          <Feather name="home" size={props.size} color={props.color} />
        ),
      }}
    />
    { ehInstituicao == true ? null : <AppTabs.Screen
      name="Explorar"
      component={ExploreProjectsStackScreen}
      options={{
        tabBarIcon: props => (
          <Feather name="globe" size={props.size} color={props.color} />
        ),
      }}
    />}
    <AppTabs.Screen
      name="Perfil"
      component={ProfileStackScreen}
      options={{
        tabBarIcon: props => (
          <Feather
            name="user" size={props.size} color={props.color}
          />
        ),
      }}
    />
  </AppTabs.Navigator>
  )};

const AuthStack = createStackNavigator();
const AuthStackScreen = () => (
  <AuthStack.Navigator screenOptions={{ headerShown: false }}>
    <AuthStack.Screen name="Login" component={Login} />
    <AuthStack.Screen name="CreateAccount" component={CreateAccount} />
    <AuthStack.Screen name="ForgottenPassword" component={ForgottenPassword} />
    <AuthStack.Screen name="Home" component={AppTabsScreen} />
    <AuthStack.Screen name="Info" component={Info} />
  </AuthStack.Navigator>
);

export default function () {

  const [user, setUser] = React.useState();

  React.useEffect(() => {
    async function canAccess() {

      setUser(
        await Auth.isLogado()
      );
    }

    canAccess();

  }, []);

  return (
    <NavigationContainer>
      {user ? (<AppTabsScreen />) : (<AuthStackScreen />)}
    </NavigationContainer>
  );
};