<template>
  <div ref="dom" class="charts chart-radar"></div>
</template>

<script>
import echarts from "echarts";
import tdTheme from "./theme.json";
import { on, off } from "@/libs/tools";
echarts.registerTheme("tdTheme", tdTheme);
export default {
  name: "ChartRadar",
  props: {
    subtext: String,
    text: String,
    data: Object
  },
  data() {
    return {
      dom: null
    };
  },
  methods: {
    resize() {
      this.dom.resize();
    },
    BindData() {
      this.$nextTick(() => {
        let option = {
          title: {
            text: this.text,
            subtext: this.subtext
          },
          radar: {
            name: {
              textStyle: {
                color: "#fff",
                backgroundColor: "#999",
                borderRadius: 3,
                padding: [3, 5]
              }
            },
            indicator: this.data.indicator,
            radius:'50%'
          },
          tooltip: {
            //   trigger: 'item',
            //   formatter: '{a} <br/>{b} : {c} ({d}%)'
          },
          legend: {
             // show:false,
            data: this.data.legend
          },
          series: this.data.series
        };
        this.dom = echarts.init(this.$refs.dom, "tdTheme");
        this.dom.setOption(option);
        on(window, "resize", this.resize);
      });
    }
  },
  mounted() {
    this.BindData();
  },
  beforeDestroy() {
    off(window, "resize", this.resize);
  }
};
</script>
