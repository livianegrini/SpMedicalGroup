import React, { Component } from 'react'

import {
    Image,
    StatusBar,
    StyleSheet,
    View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

// import Login from './login';
// import ListarConsultas from './ListarConsultas';
// import { isFlowBaseAnnotation } from '@babel/types';
import ListarConsultas from './listarconsultas';
import Login from './login';


class Main extends Component {

    render() {
        return (
            <View style={styles.main}>
                {/* <StatusBar
                    hidden={false}
                /> */}

                <bottomTab.Navigator
                    initialRouteName='ListarConsultas'

                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {
                            // if (route.name === 'Conulta') {
                            //     return (
                            //         <Image
                            //             source={require('../../assets/img/listagem.png')}
                            //             style={styles.tabBarIcon} />

                            //     )
                            // }
                            // if (route.name === 'Login') {
                            //     return (
                            //         <Image
                            //             source={require('../../assets/img/cadastrar.png')}
                            //             style={styles.tabBarIcon} />

                            //     )
                            // }
                        },

                        headerShown: false,
                        tabBarShowLabel: false,
                        tabBarActiveBackgroundColor: '#B727FF',
                        tabBarInactiveBackgroundColor: '#DD99FF',
                        tabBarStyle: { height: 50 }
                    })}
                >
                    <bottomTab.Screen name="ListarConsultas" component={ListarConsultas} />
                    <bottomTab.Screen name="Login" component={Login} />
                    {/* <bottomTab.Screen name="Perfil" component={Perfil} /> */}
                </bottomTab.Navigator>

            </View>
            // <View>
            //     <StatusBar>
            //         hidden={isFlowBaseAnnotation}
            //     </StatusBar>

            //     <bottomTab.Navigator      
            //         initialRouteName='Login'

            //         screenOptions={({ Route }) => ({
            //             tabBarIcon: () => {
            //                 if (Route.name === 'ListarProjetos') {
            //                     return (
            //                         <Image>
            //                             source={require('../../assets/Listagem.png')}
            //                         </Image>
            //                     )
            //                 }
            //                 if (Route.name === 'Login') {
            //                     return (
            //                         <Image>
            //                             source={require('../../assets/Login.png')}
            //                         </Image>
            //                     )
            //                 }
            //             },

            //             headerShown: false,
            //             tabBarShowLabel: false,
            //             tabBarActiveBackgroundColor: '#B727FF',
            //             tabBarInactiveBackgroundColor: '#DD99FF',
            //             tabBarStyle: { height: 50 }
            //         })}
            //     >

            //         <bottomTab.Screen name="ListarProjetos" component={ListarProjetos} />
            //         <bottomTab.Screen name="Login" component={Login} />

            //     </bottomTab.Navigator>
            // </View>
        )
    }
};

const styles = StyleSheet.create({

    // conteúdo da main
    main: {
        flex: 1,
        backgroundColor: '#F1F1F1'
    },

    // estilo dos ícones da tabBar
    tabBarIcon: {
        width: 22,
        height: 22
    }

});

export default Main;