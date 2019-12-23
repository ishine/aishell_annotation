<template>
  <div ref="dom" class="charts chart-bar"></div>
</template>

<script>
import echarts from "echarts";
import tdTheme from "./theme.json";
import { on, off } from "@/libs/tools";
echarts.registerTheme("tdTheme", tdTheme);
export default {
  name: "ChartBar",
  props: {
    data:Object,
    text: String,
    subtext: String,
    showBarLabel:Boolean,
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
    //todo:应该可以带如option，然后可以合并option
    BindData() {
      this.$nextTick(() => {
        var labelOption = {
          normal: {
            show: true,
            position: 'top',
            formatter:function(e){
              return (e.value).toFixed(2);
            },
            fontSize: 9,
          }
        };
        let option = {
          title: {
            text: this.text,
            subtext: this.subtext,
            x: "center"
          },
          xAxis: this.data.xAxis,
          yAxis: {
            type: "value"
          },
          series: this.data.series,
          tooltip: {
            trigger: "axis"
          },
          legend:this.data.legend
        };
        if(this.isFormatter){
          for(let i in  option.series){
              option.series[i].label=labelOption;
          }
        }
        this.dom = echarts.init(this.$refs.dom, "tdTheme");
        this.dom.setOption(option);
        let _this = this;
        this.dom.on("dblclick", function(params) {
          _this.$emit("click", params);
        });
        on(window, "resize", this.resize);
      });
    }
  },
  mounted() {
    let _this = this;
    //_this.BindData();
  },
  beforeDestroy() {
    off(window, "resize", this.resize);
  }
};
</script>
