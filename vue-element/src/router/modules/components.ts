import { RouteConfig } from 'vue-router'
import Layout from '@/layout/index.vue'

const componentsRouter: RouteConfig = {
  path: '/components',
  component: Layout,
  redirect: 'noRedirect',
  name: 'ComponentDemo',
  meta: {
    title: 'components',
    icon: 'component'
  },
  children: [
    {
      path: 'tinymce',
      component: () => import(/* webpackChunkName: "tinymce" */ '@/views/components-demo/tinymce.vue'),
      name: 'TinymceDemo',
      meta: { title: 'tinymce' }
    },
    {
      path: 'markdown',
      component: () => import(/* webpackChunkName: "markdown" */ '@/views/components-demo/markdown.vue'),
      name: 'MarkdownDemo',
      meta: { title: 'markdown' }
    },
    {
      path: 'avatar-upload',
      component: () => import(/* webpackChunkName: "avatar-upload" */ '@/views/components-demo/avatar-upload.vue'),
      name: 'AvatarUploadDemo',
      meta: { title: 'avatarUpload' }
    },
    {
      path: 'dropzone',
      component: () => import(/* webpackChunkName: "dropzone" */ '@/views/components-demo/dropzone.vue'),
      name: 'DropzoneDemo',
      meta: { title: 'dropzone' }
    },
    {
      path: 'back-to-top',
      component: () => import(/* webpackChunkName: "back-to-top" */ '@/views/components-demo/back-to-top.vue'),
      name: 'BackToTopDemo',
      meta: { title: 'backToTop' }
    }
  ]
}

export default componentsRouter
